namespace TrainsOnline.Desktop.Infrastructure.DTO.Authentication
{
    using TrainsOnline.Desktop.Infrastructure.DTO;

    public class LoginRequest : IDataTransferObject
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
