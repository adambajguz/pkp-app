namespace TrainsOnline.Api.CustomMiddlewares
{
    using System;
    using Microsoft.AspNetCore.Http;
    using SoapCore.Extensibility;
    using SoapCore.ServiceModel;
    using TrainsOnline.Application.Interfaces;

    public class SoapJwtMiddleware : IServiceOperationTuner
    {
        private IJwtService JwtService { get; }

        public SoapJwtMiddleware(IJwtService jwtService)
        {
            JwtService = jwtService;
        }

        public void Tune(HttpContext httpContext, object serviceInstance, OperationDescription operation)
        {
            JwtService.ValidateStringToken(httpContext.Request.Headers["jwt"]);

            if (!JwtService.IsTokenStringValid(httpContext.Request.Headers["jwt"]))
                throw new UnauthorizedAccessException();
        }
    }
}
