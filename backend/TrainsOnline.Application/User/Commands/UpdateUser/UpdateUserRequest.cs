namespace TrainsOnline.Application.Main.User.Commands.UpdateUser
{
    using System;
    using AutoMapper;
    using Application.CommonDTO;
    using Application.Interfaces.Mapping;
    using Domain.Entities;

    public class UpdateUserRequest : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<UpdateUserRequest, User>();
        }
    }
}
