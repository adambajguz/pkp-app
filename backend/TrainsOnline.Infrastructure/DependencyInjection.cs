namespace TrainsOnline.Infrastructure
{
    using Application.Interfaces;
    using Infrastructure.DataRights;
    using Infrastructure.UoW;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Infrastructure.Jwt;
    using TrainsOnline.Infrastructure.Main.Email;
    using TrainsOnline.Infrastructure.PdfBuilder;
    using TrainsOnline.Infrastructure.UserManager;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureContent(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment _)
        {
            //services.AddTransient<IMachineDateTimeService, MachineDateTimeService>();
            //services.AddTransient<ICsvFileBuilderService, CsvFileBuilderService>();

            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IEmailService, EmailService>();

            services.AddScoped<IPKPAppDbUnitOfWork, PKPAppDbUnitOfWork>();

            services.AddScoped<IDataRightsService, DataRightsService>();
            services.AddSingleton<IUserManagerService, UserManagerService>();
            services.AddSingleton<IPdfBuilderService, PdfBuilderService>();

            // Set license key to use GemBox.Document in Free mode.
            GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            //email configruation
            {
                IConfigurationSection emailSettings = configuration.GetSection("EmailSettings");
                services.Configure<EmailSettings>(emailSettings);
            }

            //jwt authentication configuration
            {
                IConfigurationSection jwtSettingsSection = configuration.GetSection("JwtSettings");
                services.Configure<JwtSettings>(jwtSettingsSection);

                JwtSettings jwtSettings = jwtSettingsSection.Get<JwtSettings>();
                byte[] key = Base64UrlEncoder.DecodeBytes(jwtSettings.Key);
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = JwtService.GetValidationParameters(key);
                });
            }

            return services;
        }
    }
}
