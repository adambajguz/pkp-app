namespace TrainsOnline.Api
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Serilog;
    using TrainsOnline.Api.Filters;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            //services.AddHealthChecks()
            //        .AddDbContextCheck<TrainsOnlineDbContext>();

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            services.AddHttpContextAccessor();

            //ReverseProxy configuration
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                //options.KnownProxies.Add(IPAddress.Parse("52.143.144.236"));
            });

            //Mvc
            services.AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                    .AddNewtonsoftJson()
                    //.AddJsonOptions(options =>
                    //{
                    //    //JSON serializer convedrters
                    //    options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                    //})
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //TODO add response compression
            services.AddResponseCompression();

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

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = VersionHelper.AppVersion,
                    Title = "TrainsOnline",
                    Description = "Backend Api for TrainsOnline.\n"
                });

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Use /api/login endpoint below to retrive token, then paste it to the textbox below:",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme, //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
