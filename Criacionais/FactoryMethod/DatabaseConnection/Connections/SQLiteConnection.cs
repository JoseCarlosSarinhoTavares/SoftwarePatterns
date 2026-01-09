using DatabaseConnection.Connections.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace DatabaseConnection.Connections
{
    public class SQLiteConnection : IDbConnection
    {
        private readonly string _connectionString;

        public SQLiteConnection(string connectionString) { _connectionString = connectionString; }

        public DbConnection Connect()
        {
            try
            {
                var connection = new SqliteConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Erro ao conectar no SQLite", ex);
            }
        }
    }
}
