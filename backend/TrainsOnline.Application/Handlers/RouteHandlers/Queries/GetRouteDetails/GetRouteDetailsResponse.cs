namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;

    public class GetRouteDetailsResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public GetStationDetailsResponse From { get; set; } = default!;
        public GetStationDetailsResponse To { get; set; } = default!;

        public DateTime DepartureTime { get; set; } = default!;
        public TimeSpan Duration { get; set; } = default!;
        public double Distance { get; set; }
        public double TicketPrice { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Route, GetRouteDetailsResponse>();
        }
    }
}
