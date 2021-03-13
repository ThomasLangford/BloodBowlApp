using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace BloodBowlAPI.Contexts
{
    public class BloodBowlAPIContextFactory : IDesignTimeDbContextFactory<BloodBowlAPIContext>
    {


        // "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"
        //Design-time DbContext Creation
        //ToDo Docstings and Unit Tests
        public BloodBowlAPIContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(environment) || environment.ToLower() == "development";

            var builder = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BloodBowlAPI"))
               .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{environment}.json", optional: true);

            if (isDevelopment)
            {
                builder.AddUserSecrets<BloodBowlAPIContextFactory>();
            }

            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<BloodBowlAPIContext>();

            //throw new Exception(configuration["Database.ConnectionString"]);

            optionsBuilder.UseSqlServer(configuration["Database.ConnectionString"], b => b.MigrationsAssembly("BloodBowlMigrations"));
            optionsBuilder.EnableDetailedErrors();

            return new BloodBowlAPIContext(optionsBuilder.Options);
        }
    }
}
