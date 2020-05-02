namespace TrainsOnline.Desktop.Infrastructure.DTO.Authentication
{
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class ResetPasswordRequest : IDataTransferObject
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
