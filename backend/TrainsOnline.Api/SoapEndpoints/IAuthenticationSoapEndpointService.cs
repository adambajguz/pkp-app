namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.Authentication.Commands.ResetPassword;
    using TrainsOnline.Application.Authentication.Queries.GetResetPasswordToken;
    using TrainsOnline.Application.Authentication.Queries.GetValidToken;

    [ServiceContract]
    public interface IAuthenticationSoapEndpointService : ISoapEndpointService
    {
        [OperationContract]
        Task<JwtTokenModel> Login(LoginRequest model);

        [OperationContract]
        Task<Unit> ResetPassword(ResetPasswordRequest request);

        [OperationContract]
        Task<string> ResetPassword(SendResetPasswordRequest request);
    }
}