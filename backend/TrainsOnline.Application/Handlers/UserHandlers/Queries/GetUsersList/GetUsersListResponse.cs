namespace TrainsOnline.Application.Handlers.UserHandlers.Queries.GetUsersList
{
    using System;
    using System.Collections.Generic;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Domain.Entities;

    public class GetUsersListResponse : IDataTransferObject
    {
        public IList<UserLookupModel> Users { get; set; } = default!;

        public class UserLookupModel : IDataTransferObject, ICustomMapping
        {
            public Guid Id { get; set; }

            public DateTime CreatedOn { get; set; }
            public Guid? CreatedBy { get; set; }
            public DateTime LastSavedOn { get; set; }
            public Guid? LastSavedBy { get; set; }

            public string Email { get; set; } = default!;

            public string Name { get; set; } = default!;
            public string Surname { get; set; } = default!;
            public string PhoneNumber { get; set; } = default!;
            public string Address { get; set; } = default!;

            public bool IsAdmin { get; set; }

            void ICustomMapping.CreateMappings(Profile configuration)
            {
                configuration.CreateMap<User, UserLookupModel>();
            }
        }
    }
}
