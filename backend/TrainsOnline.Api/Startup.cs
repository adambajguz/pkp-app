namespace TrainsOnline.Api
{
    using System.ServiceModel;
    using Application;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpOverrides;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;
    using Persistence;
    using Serilog;
    using SoapCore;
    using TrainsOnline.Api.Configuration;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints;
    using TrainsOnline.Api.SpecialPages;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Common;

    //TODO add api key
    public class Startup
    {
        private IServiceCollection? _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(cfg =>
            //    {
            //        cfg.AddProfile(new AutoMapperProfile(typeof(Application.Content.DependencyInjection).GetTypeInfo().Assembly));
            //    },
            //    new Assembly[] {
            //        typeof(Application.Content.DependencyInjection).GetTypeInfo().Assembly
            //    },
            //    serviceLifetime: ServiceLifetime.Singleton);

            //services.AddMediatR(new Assembly[] {
            //    typeof(Application.Content.DependencyInjection).GetTypeInfo().Assembly
            //    });

            services.AddInfrastructureContent(Configuration, Environment)
                    .AddPersistenceContent(Configuration, Environment)
                    .AddApplicationContent(Configuration, Environment)
                    .AddApi(Configuration, Environment)
                    .ConfigureSoapServices();

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseSerilogRequestLogging();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSoapServices();
            });

            if (Environment.IsDevelopment() || GlobalAppConfig.DEV_MODE)
            {
                app.UseDeveloperExceptionPage();
                app.RegisteredServicesPageX(_services);
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();
            //app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.ConfigureSwagger();
        }
    }
}
