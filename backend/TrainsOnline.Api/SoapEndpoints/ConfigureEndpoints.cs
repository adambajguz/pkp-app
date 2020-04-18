namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using SoapCore;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Application.Interfaces;

    public static class ConfigureEndpoints
    {
        private const string BaseUrl = "/soap-api";

        //TODO maybe add auto soap resolver with reflection
        public static IServiceCollection AddSoapApiServices(this IServiceCollection services)
        {
            services.AddSoapCore()
                    .AddSoapServiceOperationTuner(new SoapJwtMiddleware(services.BuildServiceProvider()
                                                                                .GetService<IJwtService>()));

            services.AddTransient<IAuthenticationSoapEndpointService, AuthenticationSoapEndpointService>();

            return services;
        }

        public static IEndpointRouteBuilder MapSoapServices(this IEndpointRouteBuilder routes)
        {
            routes.UseSoapEndpoint<IAuthenticationSoapEndpointService>(BaseUrl + "/authentication", new BasicHttpBinding(), SoapSerializer.XmlSerializer);

            return routes;
        }
    }
}
