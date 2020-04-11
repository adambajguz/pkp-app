namespace TrainsOnline.Application.Main.Authentication.Queries.GetValidToken
{
    using Application.CommonDTO;

    public class LoginRequest : IDataTransferObject
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
