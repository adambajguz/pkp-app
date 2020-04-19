namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket
{
    using Domain.Entities;
    using FluentValidation;
    using TrainsOnline.Application.Interfaces.UoW.Generic;

    public class UpdateStationeCommandValidator : AbstractValidator<UpdateStationeCommandValidator.Model>
    {
        public UpdateStationeCommandValidator(IPKPAppDbUnitOfWork uow)
        {

        }

        public class Model
        {
            public UpdateTicketRequest Data { get; set; }
            public Ticket Ticket { get; set; }

            public Model(UpdateTicketRequest data, Ticket ticket)
            {
                Data = data;
                Ticket = ticket;
            }
        }
    }
}
