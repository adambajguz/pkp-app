namespace TrainsOnline.Application.User.Queries.GetUsersList
{
    using System;
    using System.Collections.Generic;
    using Application.Interfaces.Mapping;
    using AutoMapper;
    using Domain.Entities;
    using TrainsOnline.Application.DTO;

    public class GetUsersListResponse : IDataTransferObject
    {
        public IList<UserLookupModel> Users { get; set; } = default!;

        public class UserLookupModel : IDataTransferObject, ICustomMapping
        {
            public Guid Id { get; set; }
            public DateTime CreatedOn { get; set; }

            public string Username { get; set; } = default!;

            void ICustomMapping.CreateMappings(Profile configuration)
            {
                configuration.CreateMap<User, UserLookupModel>();
            }
        }
    }
}
