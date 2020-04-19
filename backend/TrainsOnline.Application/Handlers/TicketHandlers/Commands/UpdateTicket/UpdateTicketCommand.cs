namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class UpdateTicketCommand : IRequest
    {
        public UpdateTicketRequest Data { get; }

        public UpdateTicketCommand(UpdateTicketRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<UpdateTicketCommand, Unit>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
            {
                UpdateTicketRequest data = request.Data;

                Ticket ticket = await _uow.TicketsRepository.GetByIdAsync(data.Id);

                UpdateStationeCommandValidator.Model validationModel = new UpdateStationeCommandValidator.Model(data, ticket);
                await new UpdateStationeCommandValidator(_uow).ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _mapper.Map(data, ticket);
                _uow.TicketsRepository.Update(ticket);

                await _uow.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
