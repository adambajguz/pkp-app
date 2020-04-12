namespace TrainsOnline.Application.User.Commands.UpdateUser
{
    using System;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.Common.DTO;

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
