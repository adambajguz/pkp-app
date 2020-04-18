namespace TrainsOnline.Api.SoapEndpoints
{
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.Authentication.Commands.ResetPassword;
    using TrainsOnline.Application.Authentication.Queries.GetResetPasswordToken;
    using TrainsOnline.Application.Authentication.Queries.GetValidToken;
    using TrainsOnline.Application.Interfaces;

    public class AuthenticationSoapEndpointService : IAuthenticationSoapEndpointService
    {
        protected IMediator Mediator { get; }
        protected IDataRightsService DataRights { get; }

        public AuthenticationSoapEndpointService(IMediator mediator, IDataRightsService dataRights)
        {
            Mediator = mediator;
            DataRights = dataRights;
        }

        public async Task<JwtTokenModel> Login(LoginRequest model)
        {
            return await Mediator.Send(new GetValidTokenQuery(model));
        }

        public async Task<string> ResetPassword(SendResetPasswordRequest request)
        {
            return await Mediator.Send(new GetResetPasswordTokenQuery(request));
        }

        public async Task ResetPassword(ResetPasswordRequest request)
        {
            await Mediator.Send(new ResetPasswordCommand(request));
        }
    }
}
