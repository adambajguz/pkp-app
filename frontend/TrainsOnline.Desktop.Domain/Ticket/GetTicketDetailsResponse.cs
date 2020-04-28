﻿namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails
{
    using System;
    using TrainsOnline.Application.DTO;

    public class GetTicketDetailsResponse : IDataTransferObject
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public Guid UserId { get; set; }
        //public Guid RouteId { get; set; }

        public TicketRouteDetailsModel Route { get; set; }

        public class TicketRouteDetailsModel : IDataTransferObject
        {
            public Guid Id { get; set; }

            //public Guid FromId { get; set; }
            //public Guid ToId { get; set; }

            public TicketStationDetailsModel From { get; set; }
            public TicketStationDetailsModel To { get; set; }

            public DateTime DepartureTime { get; set; }
            public TimeSpan Duration { get; set; }
            public double Distance { get; set; }
            public double TicketPrice { get; set; }

            public class TicketStationDetailsModel : IDataTransferObject
            {
                public Guid Id { get; set; }

                public string Name { get; set; }

                public double Latitude { get; set; }
                public double Longitude { get; set; }
            }
        }
    }
}
