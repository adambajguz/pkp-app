namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails;
    using TrainsOnline.Application.Interfaces.Mapping;
    using TrainsOnline.Domain.Entities;

    public class GetTicketsListResponse : IDataTransferObject
    {
        public IList<TicketLookupModel> Ticket { get; set; } = default!;

        public class TicketLookupModel : IDataTransferObject, ICustomMapping
        {
            public Guid Id { get; set; }

            public Guid UserId { get; set; }
            public Guid RouteId { get; set; }

            public GetRouteDetailResponse Route { get; set; } = default!;

            void ICustomMapping.CreateMappings(Profile configuration)
            {
                configuration.CreateMap<Ticket, TicketLookupModel>();
            }
        }
    }
}
