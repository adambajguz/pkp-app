namespace TrainsOnline.Application.Route.Commands.CreateRoute
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.DTO;

    public class CreateRouteRequest : IDataTransferObject, ICustomMapping
    {
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public DateTime DepartureTime { get; set; } = default!;
        public TimeSpan Duration { get; set; } = default!;
        public double Distance { get; set; }
        public double TicketPrice { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CreateRouteRequest, User>();
        }
    }
}
