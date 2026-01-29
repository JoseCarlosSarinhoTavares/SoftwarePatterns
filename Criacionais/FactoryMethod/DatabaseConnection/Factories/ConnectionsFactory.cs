using DatabaseConnection.Connections;
using DatabaseConnection.Connections.Interfaces;

namespace DatabaseConnection.Factories
{
    /// <summary>
    /// Fábrica para criação de conexões de banco de dados.
    /// Suporta SQL Server e SQLite.
    /// </summary>
    public class ConnectionsFactory
    {
        /// <summary>
        /// Retorna uma conexão de banco de dados do tipo especificado.
        /// </summary>
        /// <param name="tipo">Tipo de conexão: "sqlserver" ou "sqlite".</param>
        /// <returns>Objeto que implementa <see cref="IDbConnection"/>.</returns>
        /// <exception cref="ArgumentException">Lançado se o tipo for inválido ou não suportado.</exception>
        public static IDbConnection GetConnection(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo de conexão inválido");

            switch (tipo.ToLower())
            {
                case "sqlserver":
                    return GetSQLServerConnection();

                case "sqlite":
                    return GetSQLiteConnection();

                default:
                    throw new ArgumentException("Tipo de conexão não suportado");
            }
        }

        /// <summary>
        /// Cria e retorna uma conexão com SQL Server usando LocalDB.
        /// </summary>
        /// <returns>Instância de <see cref="SqlServerConnection"/>.</returns>
        private static IDbConnection GetSQLServerConnection()
        {
            return new SqlServerConnection(
                "Server=(localdb)\\mssqllocaldb;Database=SoftwarePatterns;Trusted_Connection=True;"
            );
        }

        /// <summary>
        /// Cria e retorna uma conexão com SQLite.
        /// O banco é armazenado no diretório base da aplicação.
        /// </summary>
        /// <returns>Instância de <see cref="SQLiteConnection"/>.</returns>
        private static IDbConnection GetSQLiteConnection()
        {
            return new SQLiteConnection(
                $"Data Source={Path.Combine(AppContext.BaseDirectory, "SoftwarePatterns.db")}"
            );
        }
    }
}