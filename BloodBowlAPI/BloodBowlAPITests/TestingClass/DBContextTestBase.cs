using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.TestingClass
{
    public abstract class DBContextTestBase<T> : EntityFrameworkControllerTestBase<T> where T : DbContext
    {
        public DBContextTestBase() : base() { }

        protected override T GetDBContext()
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseSqlite(_connection)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;

            return (T)Activator.CreateInstance(typeof(T), options);
        }
    }
}
