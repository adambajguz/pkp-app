namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.DeleteTicket
{
    using Application.Constants;
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.DTO;

    public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommandValidator.Model>
    {
        public DeleteTicketCommandValidator()
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                Ticket ticketResult = request.Ticket;
                if (ticketResult == null)
                    return false;

                return true;
            }).WithMessage(ValidationMessages.Id.IsIncorrectId);
        }

        public class Model
        {
            public IdRequest Data { get; set; }
            public Ticket Ticket { get; set; }

            public Model(IdRequest data, Ticket ticket)
            {
                Data = data;
                Ticket = ticket;
            }
        }
    }
}
