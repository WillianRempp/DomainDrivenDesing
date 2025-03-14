using Microsoft.Data.Sqlite;

namespace IntegratedTests.Helpers
{
    public class DatabaseFixture : IDisposable
    {
        public SqliteConnection db { get; private set; }

        public DatabaseFixture()
        {
            db = new SqliteConnection("DataSource=:memory:");

            db.Open();

            SqliteCommand command =
                new("create table Product (Id varchar(255) primary key, Name varchar(255), Price double);", db);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}