using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.Controllers
{
    public abstract class ContextControllerTestBase<T> : EntityFrameworkControllerTestBase where T : DbContext
    {
        public ContextControllerTestBase() : base() { }

        protected T GetDBContext()
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseSqlite(_connection)
                .EnableSensitiveDataLogging()
                .Options;

            return (T)Activator.CreateInstance(typeof(T), options);
        }

        protected override void DisposeObjects()
        {
            using T dbContext = GetDBContext();
            dbContext.Database.EnsureDeleted();
        }
    }
}
