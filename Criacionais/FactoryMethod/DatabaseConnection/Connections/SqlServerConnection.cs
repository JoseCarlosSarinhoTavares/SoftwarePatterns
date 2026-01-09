using DatabaseConnection.Connections.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DatabaseConnection.Connections
{
    public class SqlServerConnection : IDbConnection
    {
        private readonly string _connectionString;

        public SqlServerConnection(string connectionString) { _connectionString = connectionString; }

        public DbConnection Connect()
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Erro ao conectar no SQL Server", ex);
            }
        }
    }
}
