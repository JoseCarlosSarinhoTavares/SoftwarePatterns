using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DatabaseAndDaos.Configuration
{
    public class SqlServerDb
    {
        private const string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=SoftwarePatterns;Trusted_Connection=True;";

        public DbConnection Initialize()
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Clients')
                    BEGIN
                        CREATE TABLE Clients (
                            Id INT IDENTITY PRIMARY KEY,
                            Name NVARCHAR(100) NOT NULL
                        )
                    END;

                    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Products')
                    BEGIN
                        CREATE TABLE Products (
                            Id INT IDENTITY PRIMARY KEY,
                            Name NVARCHAR(100) NOT NULL
                        )
                    END;
                ";

                command.ExecuteNonQuery();

                return connection;
            }
            catch (SqlException ex)
            {
                throw new ArgumentException("Erro ao conectar no SQL Server", ex);
            }
        }
    }
}