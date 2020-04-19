namespace TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Domain.Entities;

    public class UpdateTicketRequest : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }

        public virtual Route Route { get; set; } = default!;
        public virtual User User { get; set; } = default!;

        public double Distance { get; set; } = default!;
        public TimeSpan Duration { get; set; } = default!;

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<UpdateTicketRequest, Ticket>();
        }
    }
}
