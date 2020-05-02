namespace TrainsOnline.Desktop.Infrastructure.DTO.Ticket
{
    using System;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class CreateTicketRequest : IDataTransferObject
    {
        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
    }
}
