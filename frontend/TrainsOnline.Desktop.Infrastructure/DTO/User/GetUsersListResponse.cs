namespace TrainsOnline.Desktop.Infrastructure.DTO.User
{
    using System;
    using System.Collections.Generic;
    using TrainsOnline.Desktop.Infrastructure.DTO;

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
