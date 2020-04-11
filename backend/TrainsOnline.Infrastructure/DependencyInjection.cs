using TrainsOnline.Infrastructure.DataRights;
using TrainsOnline.Infrastructure.UoW;

namespace TrainsOnline.Infrastructure
{
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using Infrastructure.DataRights;
    using Infrastructure.UoW;
    using TrainsOnline.Infrastructure.Main.Email;
    using TrainsOnline.Infrastructure.Main.Jwt;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureContent(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddScoped<IDataRightsService, DataRightsService>();

            //services.AddTransient<IMachineDateTimeService, MachineDateTimeService>();
            //services.AddTransient<ICsvFileBuilderService, CsvFileBuilderService>();

            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IEmailService, EmailService>();

            services.AddScoped<IMainDbUnitOfWork, MainDbUnitOfWork>();

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
