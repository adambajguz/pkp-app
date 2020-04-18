﻿namespace TrainsOnline.Api.SoapEndpoints.Core
{
    using System.Reflection;
    using System.ServiceModel;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using SoapCore;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Common.Extensions;

    public static class ConfigureEndpoints
    {
        public static string BaseUrl { get; } = "/soap-api";

        //TODO maybe add auto soap resolver with reflection
        public static IServiceCollection AddSoapApiServices(this IServiceCollection services)
        {
            services.AddSoapCore()
                    .AddSoapServiceOperationTuner(new SoapJwtMiddleware(services.BuildServiceProvider()
                                                                                .GetService<IJwtService>()));

            //services.AddTransient<ISampleSoapEndpointService, SampleSoapEndpointService>();

            Assembly.GetExecutingAssembly()
                    .GetAllSoapEndpointServicesSpecification()
                    .ForEach(x => services.AddTransient(x.Interface, x.Service));


            return services;
        }

        public static IEndpointRouteBuilder MapSoapServices(this IEndpointRouteBuilder routes)
        {
            //routes.UseSoapEndpoint<IAuthenticationSoapEndpointService>(AuthenticationEndpoint, new BasicHttpBinding(), SoapSerializer.DataContractSerializer);

            Assembly.GetExecutingAssembly()
                    .GetAllSoapEndpointServicesSpecification()
                    .ForEach(x => routes.UseSoapEndpoint(x.Interface,
                                                         x.ResolveRoute(BaseUrl),
                                                         new BasicHttpBinding(),
                                                         SoapSerializer.DataContractSerializer));
             
            return routes;
        }
    }
}
