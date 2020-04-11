using TrainsOnline.Application.CommonDTO;

namespace TrainsOnline.Application.Authentication.Queries.GetResetPasswordToken
{
    using Application.CommonDTO;

    public class SendResetPasswordRequest : IDataTransferObject
    {
        public string? Email { get; set; }
    }
}
