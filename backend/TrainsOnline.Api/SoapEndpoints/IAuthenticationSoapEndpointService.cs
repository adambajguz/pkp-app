using System.Threading.Tasks;
using TrainsOnline.Application.Authentication.Commands.ResetPassword;
using TrainsOnline.Application.Authentication.Queries.GetResetPasswordToken;
using TrainsOnline.Application.Authentication.Queries.GetValidToken;

namespace TrainsOnline.Api.SoapEndpoints
{
    public interface IAuthenticationSoapEndpointService
    {
        Task<JwtTokenModel> Login(LoginRequest model);
        Task ResetPassword(ResetPasswordRequest request);
        Task<string> ResetPassword(SendResetPasswordRequest request);
    }
}