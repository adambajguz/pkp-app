namespace TrainsOnline.Application.Main.User.Queries.GetUserDetails
{
    using System;
    using AutoMapper;
    using Application.CommonDTO;
    using Application.Interfaces.Mapping;
    using Domain.Entities;

    public class GetUserDetailResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, GetUserDetailResponse>();
        }
    }
}
