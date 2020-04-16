﻿namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using SoapCore;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Application.Interfaces;

    public static class ConfigureEndpoints
    {
        //TODO maybe add auto soap resolver with reflection
        public static IServiceCollection ConfigureSoapServices(this IServiceCollection services)
        {
            services.AddSoapCore();

            services.AddSoapServiceOperationTuner(new SoapJwtMiddleware(services.BuildServiceProvider().GetService<IJwtService>()))
                    .AddSingleton<ISampleService, SampleService>();

            return services;
        }

        public static IEndpointRouteBuilder MapSoapServices(this IEndpointRouteBuilder routes)
        {
            routes.UseSoapEndpoint<ISampleService>("/Service.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer);
            routes.UseSoapEndpoint<ISampleService>("/Service.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);

            return routes;
        }
    }
}
