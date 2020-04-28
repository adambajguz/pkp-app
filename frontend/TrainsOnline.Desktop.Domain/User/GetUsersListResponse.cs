namespace TrainsOnline.Application.Handlers.UserHandlers.Queries.GetUsersList
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Application.DTO;

    public class GetUsersListResponse : IDataTransferObject
    {
        public List<UserLookupModel> Users { get; set; }

        public class UserLookupModel : IDataTransferObject
        {
            public Guid Id { get; set; }

            public string Email { get; set; }
        }
    }
}
