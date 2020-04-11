﻿namespace TrainsOnline.Persistence
{
    using Application.Common.Interfaces;
    using TrainsOnline.Common;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceContent(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<IPKPAppDbContext, PKPAppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(GlobalAppConfig.MAIN_DB_CONNECTION_STRING_NAME)));

            return services;
        }
    }
}
