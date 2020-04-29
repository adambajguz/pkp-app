namespace TrainsOnline.Application.Handlers.AuthenticationHandlers.Queries.GetValidToken
{
    using TrainsOnline.Desktop.Domain.DTO;

    public class LoginRequest : IDataTransferObject
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
