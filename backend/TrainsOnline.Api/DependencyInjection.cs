namespace TrainsOnline.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using TrainsOnline.Api.Configuration;
    using TrainsOnline.Api.Filters;

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
            services.AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                    .AddNewtonsoftJson()
                    //.AddJsonOptions(options =>
                    //{
                    //    //JSON serializer convedrters
                    //    options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                    //})
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

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
    }
}
