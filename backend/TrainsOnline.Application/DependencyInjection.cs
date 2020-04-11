namespace TrainsOnline.Application
{
    using System.Reflection;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationContent(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddAutoMapper(new Assembly[] { typeof(DependencyInjection).GetTypeInfo().Assembly }, serviceLifetime: ServiceLifetime.Singleton);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
