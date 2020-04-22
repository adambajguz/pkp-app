namespace TrainsOnline.Application.Handlers.UserHandlers.Queries.GetUserDetails
{
    using System;
    using System.Collections.Generic;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
    using TrainsOnline.Domain.Entities;

    public class GetUserDetailResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public string Email { get; set; } = default!;

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<GetTicketsListResponse.TicketLookupModel> Tickets { get; set; } = default!;

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, GetUserDetailResponse>()
                         .ForMember(dst => dst.Tickets, opt => opt.MapFrom(src => src.Tickets));
        }
    }
}
