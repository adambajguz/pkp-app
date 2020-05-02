namespace TrainsOnline.Desktop.Infrastructure.DTO.Ticket
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class GetTicketsListResponse : IDataTransferObject
    {
        public List<TicketLookupModel> Tickets { get; set; }
    }

    public class TicketLookupModel : IDataTransferObject
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
    }
}
