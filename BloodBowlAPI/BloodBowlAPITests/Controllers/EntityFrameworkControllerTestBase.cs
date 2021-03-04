using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.Controllers
{
    public abstract class EntityFrameworkControllerTestBase : IDisposable
    {
        protected readonly DbConnection _connection;

        public EntityFrameworkControllerTestBase()
        {
            _connection = CreateInMemoryDatabase();
        }

        protected static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose()
        {
            DisposeObjects();
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeObjects() { }
    }
}
