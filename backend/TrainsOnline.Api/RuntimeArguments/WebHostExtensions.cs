namespace TrainsOnline.Api.RuntimeArguments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using TrainsOnline.Application.Interfaces;

    public static class WebHostExtensions
    {
        public static void MigrateDatabase<TDbContext>(this IWebHost webHost) where TDbContext : IGenericDatabaseContext
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

        public static bool ValidateMigrations<TDbContext>(this IWebHost webHost) where TDbContext : IGenericDatabaseContext
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
