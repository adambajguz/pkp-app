﻿namespace TrainsOnline.Desktop.Domain.Ticket
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Desktop.Domain.DTO;

    public class GetTicketsListResponse : IDataTransferObject
    {
        public List<TicketLookupModel> Ticket { get; set; }

        public class TicketLookupModel : IDataTransferObject
        {
            public Guid Id { get; set; }

            public Guid UserId { get; set; }
            public Guid RouteId { get; set; }
        }
    }
}
