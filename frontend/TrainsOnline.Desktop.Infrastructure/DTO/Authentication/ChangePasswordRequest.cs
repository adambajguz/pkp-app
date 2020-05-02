namespace TrainsOnline.Desktop.Infrastructure.DTO.Authentication
{
    using System;
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class ChangePasswordRequest : IDataTransferObject
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
