namespace TrainsOnline.Application.Handlers.AuthenticationHandlers.Queries.GetResetPasswordToken
{
    using TrainsOnline.Desktop.Domain.DTO;

    public class SendResetPasswordRequest : IDataTransferObject
    {
        public string Email { get; set; }
    }
}
