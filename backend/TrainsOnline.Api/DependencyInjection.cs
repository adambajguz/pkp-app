﻿namespace TrainsOnline.Api
{
    using System.IO.Compression;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using TrainsOnline.Api.Configuration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddRestApi(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            services.AddHttpContextAccessor();

            //ReverseProxy configuration
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                //options.KnownProxies.Add(IPAddress.Parse("52.143.144.236"));
            });

            //Mvc
            services.AddControllers()
                    .AddNewtonsoftJson()
                    //.AddJsonOptions(options =>
                    //{
                    //    //JSON serializer convedrters
                    //    options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                    //})
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;

                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

                options.MimeTypes = new[]
                {
                     // General
                    "text/plain",

                    // Static files
                    "text/css",
                    "application/javascript",
                    "font/woff2",

                    // MVC
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",

                    // WebAssembly
                    "application/wasm",

                    // Images
                    "image/*"
                };
                options.ExcludedMimeTypes = new[]
                {
                    "audio/*",
                    "video/*"
                };
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            //Cors
            services.AddCors(options => //TODO: Change cors only to our server
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        //  .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                        // .AllowCredentials();
                    });
            });

            services.AddSwagger();

            return services;
        }
    }
}
