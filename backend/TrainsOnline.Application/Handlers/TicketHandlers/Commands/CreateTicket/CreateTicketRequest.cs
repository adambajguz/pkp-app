namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Domain.Entities;

    public class CreateTicketRequest : IDataTransferObject, ICustomMapping
    {
        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }

        public double Distance { get; set; } = default!;
        public TimeSpan Duration { get; set; } = default!;

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CreateTicketRequest, Ticket>();
        }
    }
}
