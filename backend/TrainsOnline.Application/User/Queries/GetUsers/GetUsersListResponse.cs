namespace TrainsOnline.Application.Main.User.Queries.GetUsers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Application.CommonDTO;
    using Application.Interfaces.Mapping;
    using Domain.Entities;

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
