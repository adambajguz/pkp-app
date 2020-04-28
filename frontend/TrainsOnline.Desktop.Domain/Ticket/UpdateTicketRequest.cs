namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket
{
    using System;
    using TrainsOnline.Application.DTO;

    public class UpdateTicketRequest : IDataTransferObject
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
    }
}
