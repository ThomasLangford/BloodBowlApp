using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.TestingClass
{
    public abstract class EntityFrameworkControllerTestBase<T> : IDisposable where T : DbContext
    {
        protected readonly DbConnection _connection;

        public EntityFrameworkControllerTestBase()
        {
            _connection = GetDbConnection();
        }

        protected abstract DbConnection GetDbConnection();

        protected abstract T GetDBContext();      

        public void Dispose()
        {
            DisposeObjects();
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeObjects()
        {
            using T dbContext = GetDBContext();
            dbContext.Database.EnsureDeleted();
        }
    }
}
