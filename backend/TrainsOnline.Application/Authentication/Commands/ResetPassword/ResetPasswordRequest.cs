namespace TrainsOnline.Application.Authentication.Commands.ResetPassword
{
    using TrainsOnline.Application.Common.DTO;

    public class ResetPasswordRequest : IDataTransferObject
    {
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
