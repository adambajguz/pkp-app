namespace TrainsOnline.Desktop.Infrastructure.DTO.User
{
    using AutoMapper;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.ValueObjects.User;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class CreateUserRequest : IDataTransferObject, ICustomMapping
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public bool IsAdmin { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<NewUser, CreateUserRequest>();
        }
    }
}
