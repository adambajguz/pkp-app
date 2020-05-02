namespace TrainsOnline.Desktop.Infrastructure.DTO.User
{
    using System;
    using AutoMapper;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.ValueObjects.UserComponents;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class GetUserDetailsResponse : IDataTransferObject, ICustomMapping
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastSavedOn { get; set; }
        public Guid? LastSavedBy { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public bool IsAdmin { get; set; }

        void ICustomMapping.CreateMappings(Profile configuration)
        {
            configuration.CreateMap<UserDetailsValueObject, GetUserDetailsResponse>();
        }
    }
}
