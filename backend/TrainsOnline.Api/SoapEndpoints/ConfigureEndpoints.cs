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
        #region Endpoints
        public static string BaseUrl { get; } = "/soap-api";
        public static string AuthenticationEndpoint { get; } = BaseUrl + "/authentication";
        public static string UserEndpoint { get; } = BaseUrl + "/user";
        #endregion

        //TODO maybe add auto soap resolver with reflection
        public static IServiceCollection AddSoapApiServices(this IServiceCollection services)
        {
            services.AddSoapCore()
                    .AddSoapServiceOperationTuner(new SoapJwtMiddleware(services.BuildServiceProvider()
                                                                                .GetService<IJwtService>()));

            services.AddTransient<IAuthenticationSoapEndpointService, AuthenticationSoapEndpointService>();
            services.AddTransient<IUserSoapEndpointService, UserSoapEndpointService>();

            return services;
        }

        public static IEndpointRouteBuilder MapSoapServices(this IEndpointRouteBuilder routes)
        {
            routes.UseSoapEndpoint<IAuthenticationSoapEndpointService>(AuthenticationEndpoint, new BasicHttpBinding(), SoapSerializer.DataContractSerializer);
            routes.UseSoapEndpoint<IUserSoapEndpointService>(UserEndpoint, new BasicHttpBinding(), SoapSerializer.XmlSerializer);

            return routes;
        }
    }
}
