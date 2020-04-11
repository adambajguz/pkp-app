namespace TrainsOnline.Application.Main.User.Commands.ChangePassword
{
    using System;
    using Application.CommonDTO;

    public class ChangePasswordRequest : IDataTransferObject
    {
        public Guid UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
