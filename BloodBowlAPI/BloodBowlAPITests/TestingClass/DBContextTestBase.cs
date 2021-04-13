using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.TestingClass
{
    public abstract class DBContextTestBase<T> : EntityFrameworkControllerTestBase<T> where T : DbContext
    {
        public DBContextTestBase() : base() { }

        protected override DbConnection GetDbConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        protected override T GetDBContext()
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseSqlite(_connection)
                .LogTo(Log)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;

            return (T)Activator.CreateInstance(typeof(T), options);
        }

        protected void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
