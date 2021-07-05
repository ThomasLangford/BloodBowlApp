using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace BloodBowlData.Contexts
{
    public class BloodBowlApiDbContextFactory : IDesignTimeDbContextFactory<BloodBowlApiDbContext>
    {


        // "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"
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

            //throw new Exception(configuration["Database.ConnectionString"]);

            optionsBuilder.UseSqlServer(configuration["Database.ConnectionString"], b => b.MigrationsAssembly("BloodBowlMigrations"));
            optionsBuilder.EnableDetailedErrors();

            return new BloodBowlApiDbContext(optionsBuilder.Options);
        }
    }
}
