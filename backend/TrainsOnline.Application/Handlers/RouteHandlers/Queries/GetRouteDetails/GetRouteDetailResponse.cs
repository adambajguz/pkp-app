namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;

    public class GetRouteDetailResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public GetStationDetailResponse From { get; set; } = default!;
        public GetStationDetailResponse To { get; set; } = default!;

        public DateTime DepartureTime { get; set; } = default!;
        public TimeSpan Duration { get; set; } = default!;
        public double Distance { get; set; }
        public double TicketPrice { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Route, GetRouteDetailResponse>();

            configuration.CreateMap<Route, GetRouteDetailResponse>()
                         .ForMember(dst => dst.From, opt => opt.MapFrom(src => src.From))
                         .ForMember(dst => dst.To, opt => opt.MapFrom(src => src.To));
        }
    }
}
