﻿namespace TrainsOnline.Application.Handlers.RouteHandlers.Commands.CreateRoute
{
    using System;
    using TrainsOnline.Application.DTO;

    public class CreateRouteRequest : IDataTransferObject
    {
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
        public double TicketPrice { get; set; }
    }
}
