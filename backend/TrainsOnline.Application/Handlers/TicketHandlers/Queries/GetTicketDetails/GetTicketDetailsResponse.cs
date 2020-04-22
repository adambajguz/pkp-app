namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.DTO;

    public class GetTicketDetailsResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Ticket, GetTicketDetailsResponse>();
        }
    }
}
