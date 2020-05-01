﻿namespace TrainsOnline.Desktop.Domain.DTO.User
{
    using System;
    using TrainsOnline.Desktop.Domain.DTO;

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
