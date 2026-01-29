using DatabaseConnection.Connections.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DatabaseConnection.Connections
{
    /// <summary>
    /// Representa uma conexão com SQL Server.
    /// </summary>
    public class SqlServerConnection : IDbConnection
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa uma nova instância da conexão SQL Server com a string de conexão informada.
        /// </summary>
        /// <param name="connectionString">String de conexão do SQL Server.</param>
        public SqlServerConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Abre e retorna uma conexão ativa com o SQL Server.
        /// </summary>
        /// <returns>Objeto <see cref="DbConnection"/> representando a conexão aberta.</returns>
        /// <exception cref="ArgumentException">Lançada se ocorrer um erro ao conectar ao SQL Server.</exception>
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