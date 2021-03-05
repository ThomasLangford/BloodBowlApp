using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace BloodbowlData.Contexts
{
    public class BloodBowlAPIContextFactory : IDesignTimeDbContextFactory<BloodBowlAPIContext>
    {
        //Design-time DbContext Creation
        //ToDo Docstings and Unit Tests
        public BloodBowlAPIContext CreateDbContext(string[] args)
        {
            //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //var config = new ConfigurationBuilder()
            //   .AddJsonFile("appsettings.json", optional: false)
            //   .AddJsonFile($"appsettings.{environment}.json", optional: true)
            //   .CreateDefaultBuilder()
            //   .Build();


            var optionsBuilder = new DbContextOptionsBuilder<BloodBowlAPIContext>();

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;", b => b.MigrationsAssembly("BloodBowlMigrations"));
            optionsBuilder.EnableDetailedErrors();

            return new BloodBowlAPIContext(optionsBuilder.Options);

        }
    }
}
