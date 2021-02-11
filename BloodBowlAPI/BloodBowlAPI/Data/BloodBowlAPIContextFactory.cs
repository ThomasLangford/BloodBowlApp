using BloodbowlAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Data
{
    public class BloodBowlAPIContextFactory : IDesignTimeDbContextFactory<BloodBowlAPIContext>
    {
        //Design-time DbContext Creation
        //ToDo Docstings and Unit Tests
        public BloodBowlAPIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloodBowlAPIContext>();

            optionsBuilder.UseMySql(
                    "server=localhost;database=bloodbowl;user=Super;password=Super",
                    new MySqlServerVersion(new Version(8, 0, 21)),
                    mySqlOptions => mySqlOptions
                    .CharSetBehavior(CharSetBehavior.NeverAppend)
                    .MigrationsAssembly("BloodBowlAPIMigrations")
                );

            return new BloodBowlAPIContext(optionsBuilder.Options);
        }
    }
}
