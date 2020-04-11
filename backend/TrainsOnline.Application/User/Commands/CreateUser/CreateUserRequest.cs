namespace TrainsOnline.Application.Main.User.Commands.CreateUser
{
    using AutoMapper;
    using Application.CommonDTO;
    using Application.Interfaces.Mapping;
    using Domain.Entities;

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
