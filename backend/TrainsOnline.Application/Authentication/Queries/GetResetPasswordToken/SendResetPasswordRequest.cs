namespace TrainsOnline.Application.Authentication.Queries.GetResetPasswordToken
{
    using TrainsOnline.Application.Common.DTO;

    public class SendResetPasswordRequest : IDataTransferObject
    {
        public string? Email { get; set; }
    }
}
