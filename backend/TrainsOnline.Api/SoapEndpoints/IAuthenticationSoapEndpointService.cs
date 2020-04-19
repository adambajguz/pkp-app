namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.Handlers.AuthenticationHandlers.Commands.ResetPassword;
    using TrainsOnline.Application.Handlers.AuthenticationHandlers.Queries.GetResetPasswordToken;
    using TrainsOnline.Application.Handlers.AuthenticationHandlers.Queries.GetValidToken;

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