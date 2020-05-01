namespace TrainsOnline.Desktop.Domain.DTO.Authentication
{
    using TrainsOnline.Desktop.Domain.DTO;

    public class SendResetPasswordRequest : IDataTransferObject
    {
        public string Email { get; set; }
    }
}
