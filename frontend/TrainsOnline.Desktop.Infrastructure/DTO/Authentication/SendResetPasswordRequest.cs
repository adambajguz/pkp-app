namespace TrainsOnline.Desktop.Infrastructure.DTO.Authentication
{
    public class SendResetPasswordRequest : IDataTransferObject
    {
        public string Email { get; set; }
    }
}
