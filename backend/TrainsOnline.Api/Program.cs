namespace TrainsOnline.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Application.Interfaces;
    using FluentValidation;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.CommandLineUtils;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Sentry;
    using Serilog;
    using Serilog.Events;
    using Serilog.Exceptions;
    using Serilog.Sinks.SystemConsole.Themes;
    using TrainsOnline.Common;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            CommandLineApplication commandLineApplication = new CommandLineApplication(true);

            CommandOption doMigrate = commandLineApplication.Option(
                "--ef-migrate",
                "Apply entity framework migrations and exit",
                CommandOptionType.NoValue);

            CommandOption verifyMigrate = commandLineApplication.Option(
                "--ef-migrate-check",
                "Check the status of entity framework migrations",
                CommandOptionType.NoValue);

            CommandOption run = commandLineApplication.Option(
                           "--run",
                           "Run webhost",
                           CommandOptionType.NoValue);

            commandLineApplication.HelpOption("--h | --show-help");
            commandLineApplication.Name = "dotnet TrainsOnline.Api.dll";
            commandLineApplication.Description = "Backend REST Api for TrainsOnline.";
            commandLineApplication.ExtendedHelpText = commandLineApplication.Description;
            commandLineApplication.FullName = GlobalAppConfig.AppInfo.AppName;
            commandLineApplication.Syntax = "TrainsOnline.Api.dll";
            commandLineApplication.VersionOption("--version", () => VersionHelper.AppShortVersion, () => VersionHelper.AppVersion);

            commandLineApplication.OnExecute(() =>
            {
                ExecuteApp(args, doMigrate, verifyMigrate, run);
                return 0;
            });

            try
            {
                commandLineApplication.Execute(args);
            }
            catch (CommandParsingException)
            {
                commandLineApplication.ShowHelp();
            }
        }

        private static void ExecuteApp(string[] args, CommandOption doMigrate, CommandOption verifyMigrate, CommandOption run)
        {
            Console.WriteLine("Loading web host");

            string action = "--run";

            if (doMigrate.HasValue())
                action = "--ef-migrate";
            else if (verifyMigrate.HasValue())
                action = "--ef-migrate-check";

            using (IWebHost webHost = RunWebHost(args, action))
            {
                if (verifyMigrate.HasValue() && doMigrate.HasValue())
                {
                    Console.WriteLine("ef-migrate and ef-migrate-check are mutually exclusive, select one, and try again");
                    Environment.Exit(2);
                }

                if (verifyMigrate.HasValue())
                {
                    bool validateResult = ValidateMigrations<IPKPAppDbContext>(webHost);

                    if (!validateResult)
                        Environment.Exit(3);

                    if (!run.HasValue())
                        Environment.Exit(0);
                }

                if (doMigrate.HasValue())
                {
                    MigrateDatabase<IPKPAppDbContext>(webHost);

                    if (!run.HasValue())
                        Environment.Exit(0);
                }

                if (run.HasValue())
                {
                    try
                    {
                        // no flags provided, so just run the webhost
                        webHost.Run();
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "Host terminated unexpectedly!");
                    }
                    finally
                    {
                        Log.Information("Closing web host...");

                        Log.CloseAndFlush();
                    }
                }
                else
                {
                    Log.Information("No --run parameter provided!");
                    Log.Information("Closing web host...");
                }
            }
        }

        private static IWebHost RunWebHost(string[] args, string action)
        {
            //Custom PropertyNameResolver to remove neasted Property in Classes e.g. Data.Id in UpdateUserCommandValidator.Model
            ValidatorOptions.PropertyNameResolver = (type, member, expression) =>
            {
                if (member != null)
                {
                    return member.Name;
                }

                return null;
            };

            LoggerSettings loggerSettigns;
            //logger configuration
            {
                IConfigurationBuilder configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
                configuration.AddJsonFile(GlobalAppConfig.AppSettingsFileName);

                loggerSettigns = configuration.Build().GetSection("LoggerSettings").Get<LoggerSettings>();
            }

            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                                         .Enrich.FromLogContext()
                                         .Enrich.WithExceptionDetails()
                                         .Enrich.WithProcessId()
                                         .Enrich.WithProcessName()
                                         .Enrich.WithThreadId();

#pragma warning disable CS0162 // Unreachable code detected
            loggerConfiguration.MinimumLevel.Information();
            string minLogLevel = "Information";

            if (GlobalAppConfig.DEV_MODE)
            {
                if (loggerSettigns.LogEverythingInDev)
                {
                    loggerConfiguration.MinimumLevel.Verbose();
                    minLogLevel = "Verbose";
                }
                else
                {
                    loggerConfiguration.MinimumLevel.Debug();
                    minLogLevel = "Debug";
                }
            }
#pragma warning restore CS0162 // Unreachable code detected

            ConfigureSentry(loggerSettigns, loggerConfiguration);

            loggerConfiguration.WriteTo.Async(a => a.Logger(WriteToConsole(loggerSettigns)));

            Log.Logger = loggerConfiguration.WriteTo.Async(WriteToFile(loggerSettigns))
                                            .CreateLogger();

#pragma warning disable CS0162 // Unreachable code detected
            {
                string mode = GlobalAppConfig.DEV_MODE ? "DEVelopment" : "PRODuction";

                Log.Warning("Server START: {Mode} mode enabled; Minimum log level - {LogLevel}; Action: {Action}", mode, minLogLevel, action);
            }

#pragma warning restore CS0162 // Unreachable code detected

            Log.Information($"Config file: {GlobalAppConfig.AppSettingsFileName}");
            Log.Information($"Logs are stored under: {loggerSettigns.FullPath}");

            ValidatorOptions.LanguageManager.Enabled = false;
            Log.Information("FluentValidation's support for localization disabled. Default English messages are forced to be used, regardless of the thread's CurrentUICulture.");
            //ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");

            Log.Information("Starting web host...");
            //.Run();
            return CreateWebHostBuilder(args).Build();

        }

        private static void ConfigureSentry(LoggerSettings loggerSettigns, LoggerConfiguration loggerConfiguration)
        {
            if (!loggerSettigns.SentryEnabled)
                return;

            loggerConfiguration.WriteTo.Sentry(o =>
            {
                // Debug and higher are stored as breadcrumbs (default is Information)
                o.MinimumBreadcrumbLevel = LogEventLevel.Debug;
                // Warning and higher is sent as event (default is Error)
                o.MinimumEventLevel = LogEventLevel.Warning;
                o.Dsn = new Dsn(loggerSettigns.SentryDSN);
                o.AttachStacktrace = true;
                o.SendDefaultPii = true;
                o.Release = GlobalAppConfig.AppInfo.SentryReleaseVersion;
                o.ReportAssemblies = true;
                o.Environment = GlobalAppConfig.DEV_MODE ? "Development" : "Production";
            });
        }

        private static Action<LoggerConfiguration> WriteToConsole(LoggerSettings loggerSettigns)
        {
            return b => b.WriteTo.Async(c => c.Console(outputTemplate: loggerSettigns.ConsoleOutputTemplate,
                                                       theme: AnsiConsoleTheme.Literate));
        }

        private static Action<Serilog.Configuration.LoggerSinkConfiguration> WriteToFile(LoggerSettings loggerSettigns)
        {
            return a => a.File(loggerSettigns.FullPath,
                               outputTemplate: loggerSettigns.FileOutputTemplate,
                               fileSizeLimitBytes: loggerSettigns.FileSizeLimitInBytes,
                               rollingInterval: RollingInterval.Day,
                               rollOnFileSizeLimit: true,
                               flushToDiskInterval: TimeSpan.FromSeconds(loggerSettigns.FlushIntervalInSeconds),
                               retainedFileCountLimit: loggerSettigns.RetainedFileCountLimit,
                               shared: true);
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseKestrel()
                          .UseStartup<Startup>()
                          .UseSerilog()
                          .UseUrls("http://*:2137", "http://*:2138");
        }

        public static void MigrateDatabase<TDbContext>(IWebHost webHost) where TDbContext : IGenericDatabaseContext
        {
            Console.WriteLine($"Applying Entity Framework migrations for {typeof(TDbContext).Name}");

            IServiceScopeFactory serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                TDbContext dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

                dbContext.Database.Migrate();
                Console.WriteLine("All done, closing app");
            }
        }

        private static bool ValidateMigrations<TDbContext>(IWebHost webHost) where TDbContext : IGenericDatabaseContext
        {
            Console.WriteLine($"Validating status of Entity Framework migrations for {typeof(TDbContext).Name}");

            IServiceScopeFactory serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                TDbContext dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

                IEnumerable<string> pendingMigrations = dbContext.Database.GetPendingMigrations();
                IList<string> migrations = pendingMigrations as IList<string> ?? pendingMigrations.ToList();
                if (!migrations.Any())
                {
                    Console.WriteLine("No pending migratons");
                    return true;
                }

                Console.WriteLine("Pending migratons {0}", migrations.Count());
                foreach (string migration in migrations)
                {
                    Console.WriteLine($"\t{migration}");
                }

                return false;
            }
        }
    }
}