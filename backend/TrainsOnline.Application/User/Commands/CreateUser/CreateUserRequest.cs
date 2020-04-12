namespace TrainsOnline.Application.User.Commands.CreateUser
{
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.Common.DTO;

    public class CreateUserRequest : IDataTransferObject, ICustomMapping
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CreateUserRequest, User>();
        }
    }
}
