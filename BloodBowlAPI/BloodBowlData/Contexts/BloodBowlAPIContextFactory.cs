using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodbowlData.Contexts
{
    public class BloodBowlAPIContextFactory : IDesignTimeDbContextFactory<BloodBowlAPIContext>
    {
        //Design-time DbContext Creation
        //ToDo Docstings and Unit Tests
        public BloodBowlAPIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloodBowlAPIContext>();

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;", b => b.MigrationsAssembly("BloodBowlMigrations"));
            optionsBuilder.EnableDetailedErrors();

            return new BloodBowlAPIContext(optionsBuilder.Options);
        }
    }
}
