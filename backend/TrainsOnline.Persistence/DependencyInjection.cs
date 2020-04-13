namespace TrainsOnline.Persistence
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Common;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceContent(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<IPKPAppDbContext, PKPAppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(GlobalAppConfig.PKPAPP_DB_CONNECTION_STRING_NAME)));

            return services;
        }
    }
}
