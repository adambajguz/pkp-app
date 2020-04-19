namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.DeleteTicket
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class DeleteTicketCommand : IRequest
    {
        public IdRequest Data { get; }

        public DeleteTicketCommand(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<DeleteTicketCommand, Unit>
        {
            private readonly IPKPAppDbUnitOfWork _uow;

            public Handler(IPKPAppDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                Ticket ticket = await _uow.TicketsRepository.GetByIdAsync(data.Id);
                DeleteTicketCommandValidator.Model validationModel = new DeleteTicketCommandValidator.Model(data, ticket);

                await new DeleteTicketCommandValidator().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                _uow.TicketsRepository.Remove(ticket);
                await _uow.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
