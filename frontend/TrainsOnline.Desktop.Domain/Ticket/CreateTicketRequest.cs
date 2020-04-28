namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket
{
    using System;
    using TrainsOnline.Application.DTO;

    public class CreateTicketRequest : IDataTransferObject
    {
        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
    }
}
