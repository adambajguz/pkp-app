﻿namespace TrainsOnline.Desktop.Domain.Route
{
    using System;
    using TrainsOnline.Desktop.Domain.DTO;

    public class UpdateRouteRequest : IDataTransferObject
    {
        public Guid Id { get; set; }

        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
        public double TicketPrice { get; set; }
    }
}
