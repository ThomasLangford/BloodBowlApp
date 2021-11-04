using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace BloodBowlData.Contexts
{
    public class BloodBowlApiDbContextFactory : IDesignTimeDbContextFactory<BloodBowlApiDbContext>
    {
        //Design-time DbContext Creation
        //ToDo Docstings and Unit Tests
        public BloodBowlApiDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(environment) || environment.ToLower() == "development";

            var builder = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BloodBowlAPI"))
               .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{environment}.json", optional: true);

            if (isDevelopment)
            {
                builder.AddUserSecrets<BloodBowlApiDbContextFactory>();
            }

            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<BloodBowlApiDbContext>();

            // Commands:
            //  1. dotnet ef migrations add InitalMigration --project ../BloodBowlMigrations
            //  2. dotnet ef database update

            optionsBuilder.UseSqlServer(configuration["Database:ConnectionString"], b => b.MigrationsAssembly("BloodBowlMigrations"));

            if (isDevelopment)
            {
                optionsBuilder.EnableDetailedErrors();
            }

            return new BloodBowlApiDbContext(optionsBuilder.Options);
        }
    }
}
