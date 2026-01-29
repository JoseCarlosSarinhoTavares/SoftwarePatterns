using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace DatabaseAndDaos.Configuration
{
    /// <summary>
    /// Classe de configuração e inicialização do banco de dados SQLite.
    /// Cria a conexão e garante que as tabelas <c>Clients</c> e <c>Products</c> existam.
    /// </summary>
    public class SqLiteDb
    {
        /// <summary>
        /// String de conexão com o SQLite. O arquivo será criado na pasta base da aplicação.
        /// </summary>
        private static readonly string ConnectionString =
            $"Data Source={Path.Combine(AppContext.BaseDirectory, "SoftwarePatterns.db")}";

        /// <summary>
        /// Inicializa a conexão com o banco de dados e cria as tabelas se não existirem.
        /// </summary>
        /// <returns>Conexão aberta com o banco de dados SQLite.</returns>
        /// <exception cref="ArgumentException">Lançada em caso de erro ao conectar no SQLite.</exception>
        public DbConnection Initialize()
        {
            try
            {
                var connection = new SqliteConnection(ConnectionString);
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INTEGER PRIMARY KEY,
                        Name TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Products (
                        Id INTEGER PRIMARY KEY,
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