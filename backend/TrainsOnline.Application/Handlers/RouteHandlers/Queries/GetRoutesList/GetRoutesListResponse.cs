namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Interfaces.Mapping;
    using TrainsOnline.Domain.Entities;

    public class GetRoutesListResponse : IDataTransferObject
    {
        public IList<RouteLookupModel> Routes { get; set; } = default!;

        public class RouteLookupModel : IDataTransferObject, ICustomMapping
        {
            public Guid Id { get; set; }

            public Guid FromId { get; set; }
            public Guid ToId { get; set; }

            public GetStationDetailResponse From { get; set; } = default!;
            public GetStationDetailResponse To { get; set; } = default!;

            public DateTime DepartureTime { get; set; } = default!;
            public TimeSpan Duration { get; set; } = default!;

            void ICustomMapping.CreateMappings(Profile configuration)
            {
                configuration.CreateMap<Route, RouteLookupModel>()
                             .ForMember(dst => dst.From, opt => opt.MapFrom(src => src.From))
                             .ForMember(dst => dst.To, opt => opt.MapFrom(src => src.To));
            }
        }
    }
}
