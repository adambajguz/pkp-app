﻿namespace TrainsOnline.Api.RuntimeArguments
{
    using System;
    using System.Collections.Generic;
    using CommandLine;
    using FluentValidation;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
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
            using (IWebHost webHost = RunWebHost())
            {
#pragma warning disable CS0162 // Unreachable code detected
                {
                    string mode = GlobalAppConfig.DEV_MODE ? "DEVelopment" : "PRODuction";

                    Log.Warning("Server START: {Mode} mode enabled. --ef-migrate={EfMigrate} --ef-migrate-check={EfMigrateCheck} --run={Run}", mode, options.EfMigrate, options.EfMigrateCheck, options.Run);
                }

#pragma warning restore CS0162 // Unreachable code detected

                if (options.EfMigrateCheck)
                {
                    bool validateResult = webHost.ValidateMigrations<IPKPAppDbContext>();

                    if (!validateResult)
                        Environment.Exit(3);

                    if (!options.Run)
                        Environment.Exit(0);
                }

                if (options.EfMigrate)
                {
                    webHost.MigrateDatabase<IPKPAppDbContext>();

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
        private static void Pause()
        {
            Console.Write($"\nPress any key to exit . . . ");

            ConsoleKey key;
            do
                key = Console.ReadKey().Key;
            while (key == ConsoleKey.LeftWindows || key == ConsoleKey.RightWindows);
        }

        private static IWebHost RunWebHost()
        {
            SerilogConfiguration.ConfigureSerilog();

            Log.Information("Loading web host...");

            //Custom PropertyNameResolver to remove neasted Property in Classes e.g. Data.Id in UpdateUserCommandValidator.Model
            ValidatorOptions.PropertyNameResolver = (type, member, expression) =>
            {
                if (member != null)
                    return member.Name;

                return null;
            };


            ValidatorOptions.LanguageManager.Enabled = false;
            Log.Information("FluentValidation's support for localization disabled. Default English messages are forced to be used, regardless of the thread's CurrentUICulture.");
            //ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");

            Log.Information("Starting web host...");

            return CreateWebHostBuilder().Build();
        }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                          .UseKestrel()
                          .UseStartup<Startup>()
                          .UseSerilog()
                          .UseUrls("http://*:2137", "http://*:2138");
        }
        #endregion
    }
}
