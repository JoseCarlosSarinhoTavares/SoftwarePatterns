using DatabaseConnection.Connections.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace DatabaseConnection.Connections
{
    /// <summary>
    /// Representa uma conexão com SQLite.
    /// </summary>
    public class SQLiteConnection : IDbConnection
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa uma nova instância da conexão SQLite com a string de conexão informada.
        /// </summary>
        /// <param name="connectionString">String de conexão do SQLite.</param>
        public SQLiteConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Abre e retorna uma conexão ativa com o SQLite.
        /// </summary>
        /// <returns>Objeto <see cref="DbConnection"/> representando a conexão aberta.</returns>
        /// <exception cref="ArgumentException">Lançada se ocorrer um erro ao conectar ao SQLite.</exception>
        public DbConnection Connect()
        {
            try
            {
                var connection = new SqliteConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (SqliteException ex)
            {
                throw new ArgumentException("Erro ao conectar no SQLite", ex);
            }
        }
    }
}