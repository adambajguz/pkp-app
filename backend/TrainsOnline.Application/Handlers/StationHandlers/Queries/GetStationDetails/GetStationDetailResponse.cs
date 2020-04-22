﻿namespace TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails
{
    using System;
    using System.Collections.Generic;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRoutesList;

    public class GetStationDetailResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public string Name { get; set; } = default!;

        public double Latitude { get; set; } = default!;
        public double Longitude { get; set; } = default!;

        public ICollection<GetRoutesListResponse.RouteLookupModel> Departures { get; set; } = default!;
        public ICollection<GetRoutesListResponse.RouteLookupModel> Arrivals { get; set; } = default!;

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Station, GetStationDetailResponse>()
                         .ForMember(dst => dst.Departures, opt => opt.MapFrom(src => src.Departures))
                         .ForMember(dst => dst.Arrivals, opt => opt.MapFrom(src => src.Arrivals));
        }
    }
}
