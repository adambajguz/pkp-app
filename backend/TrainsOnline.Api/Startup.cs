namespace TrainsOnline.Api
{
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using Application;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpOverrides;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Persistence;
    using Serilog;
    using TrainsOnline.Api.Configuration;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints;
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

            services.AddInfrastructureContent(Configuration)
                    .AddPersistenceContent(Configuration)
                    .AddApplicationContent(Configuration, Environment)
                    .AddRestApi()
                    .AddSoapApiServices();

            services.AddHealthChecks()
                    .AddDbContextCheck<PKPAppDbContext>();

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
                //endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
                endpoints.MapSoapServices();
            });

            if (Environment.IsDevelopment() || GlobalAppConfig.DEV_MODE)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages(StatusCodePageRespone);

            app.ConfigureSpecialPages(Environment, _services);

            app.UseCustomExceptionHandler();
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.ConfigureSwagger();
        }

        private static async Task StatusCodePageRespone(StatusCodeContext statusCodeContext)
        {
            HttpResponse httpRespone = statusCodeContext.HttpContext.Response;
            httpRespone.ContentType = MediaTypeNames.Text.Plain;

            string reasonPhrase = ReasonPhrases.GetReasonPhrase(httpRespone.StatusCode);

            string response = $"{GlobalAppConfig.AppInfo.AppName} Error Page\n" +
                              $"{GlobalAppConfig.AppInfo.AppVersion}\n\n" +
                              $"Status code: {httpRespone.StatusCode} - {reasonPhrase}";

            await httpRespone.WriteAsync(response);
        }
    }
}
