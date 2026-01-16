using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace DatabaseAndDaos.Configuration
{
    public class SqLiteDb
    {
        private static readonly string ConnectionString =
            $"Data Source={Path.Combine(AppContext.BaseDirectory, "TESTE.db")}";

        public DbConnection Initialize()
        {
            try
            {
                var connection = new SqliteConnection(ConnectionString);
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Products (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL
                    );
                ";

                command.ExecuteNonQuery();

                return connection;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao conectar no SQLite", ex);
            }
            
        }
    }
}