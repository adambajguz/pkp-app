﻿namespace TrainsOnline.Api.Configuration
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TrainsOnline.Api.SpecialPages;
    using TrainsOnline.Common;

    public static class SpecialPagesConfiguration
    {
        public static IApplicationBuilder ConfigureSpecialPages(this IApplicationBuilder app, IWebHostEnvironment environment, IServiceCollection? services)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            // Register Development pages
            if (environment.IsDevelopment() || GlobalAppConfig.DEV_MODE)
            {
                app.AddRegisteredServicesPage(services);
            }

            // Register Development and Production pages
            app.AddSoapEndpointsPage();

            return app;
        }
    }
}
