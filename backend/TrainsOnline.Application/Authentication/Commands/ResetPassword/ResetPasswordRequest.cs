using TrainsOnline.Application.CommonDTO;

namespace TrainsOnline.Application.Authentication.Commands.ResetPassword
{
    using Application.CommonDTO;

    public class ResetPasswordRequest : IDataTransferObject
    {
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
