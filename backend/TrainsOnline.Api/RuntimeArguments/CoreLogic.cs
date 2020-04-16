namespace SPA.Runner.CommandLineOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommandLine;
    using FluentValidation;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using TrainsOnline.Api;
    using TrainsOnline.Api.Configuration;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Common;

    internal static class CoreLogic
    {
        #region Callbacks for CommandLine library
        public static void Execute(RuntimeOptions options)
        {
            Console.WriteLine("Loading web host");

            using (IWebHost webHost = RunWebHost(args))
            {
                if (options.EfMigrateCheck)
                {
                    bool validateResult = ValidateMigrations<IPKPAppDbContext>(webHost);

                    if (!validateResult)
                        Environment.Exit(3);

                    if (!options.Run)
                        Environment.Exit(0);
                }

                if (options.EfMigrate)
                {
                    MigrateDatabase<IPKPAppDbContext>(webHost);

                    if (!options.Run)
                        Environment.Exit(0);
                }

                if (options.Run)
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

        public static void HandleOptionsErrors(IEnumerable<Error> errors)
        {
            if (errors.IsHelp() && System.Diagnostics.Debugger.IsAttached)
                Pause();
        }
        #endregion

        #region Helpers
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

        private static void Pause()
        {
            Console.Write($"\nPress any key to exit . . . ");

            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
            } while (key == ConsoleKey.LeftWindows || key == ConsoleKey.RightWindows);
        }

        private static IWebHost RunWebHost(string[] args)
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

            SerilogConfiguration.ConfigureSerilog();

            ValidatorOptions.LanguageManager.Enabled = false;
            Log.Information("FluentValidation's support for localization disabled. Default English messages are forced to be used, regardless of the thread's CurrentUICulture.");
            //ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");

            Log.Information("Starting web host...");

            return CreateWebHostBuilder(args).Build();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseKestrel()
                          .UseStartup<Startup>()
                          .UseSerilog()
                          .UseUrls("http://*:2137", "http://*:2138");
        }
        #endregion
    }
}
