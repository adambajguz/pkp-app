namespace TrainsOnline.Application.Handlers.UserHandlers.Commands.UpdateUser
{
    using System;
    using TrainsOnline.Application.DTO;

    public class UpdateUserRequest : IDataTransferObject
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public bool IsAdmin { get; set; }
    }
}
