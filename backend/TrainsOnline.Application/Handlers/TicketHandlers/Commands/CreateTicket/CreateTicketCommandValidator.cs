namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket
{
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketRequest>
    {
        public CreateTicketCommandValidator(IPKPAppDbUnitOfWork uow)
        {

        }
    }
}
