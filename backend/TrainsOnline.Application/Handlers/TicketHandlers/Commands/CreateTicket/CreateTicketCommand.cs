namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class CreateTicketCommand : IRequest<IdResponse>
    {
        public CreateTicketRequest Data { get; }

        public CreateTicketCommand(CreateTicketRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<CreateTicketCommand, IdResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<IdResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
            {
                CreateTicketRequest data = request.Data;

                await new CreateTicketCommandValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Ticket entity = _mapper.Map<Ticket>(data);
                _uow.TicketsRepository.Add(entity);

                await _uow.SaveChangesAsync(cancellationToken);

                return new IdResponse(entity.Id);
            }
        }
    }
}
