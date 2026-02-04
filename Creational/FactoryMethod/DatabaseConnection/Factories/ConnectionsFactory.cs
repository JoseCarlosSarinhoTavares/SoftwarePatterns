using SoftwarePatterns.Creational.FactoryMethod.DatabaseConnection.Connections;
using SoftwarePatterns.Creational.FactoryMethod.DatabaseConnection.Interfaces;

namespace SoftwarePatterns.Creational.FactoryMethod.DatabaseConnection.Factories
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
        /// <returns>Objeto que implementa <see cref="IDatabaseConnection"/>.</returns>
        /// <exception cref="ArgumentException">Lançado se o tipo for inválido ou não suportado.</exception>
        public static IDatabaseConnection GetConnection(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo de conexão inválido");

            return tipo.ToLower() switch
            {
                "sqlserver" => GetSqlServerConnection(),
                "sqlite" => GetSqliteDatabaseConnection(),
                _ => throw new ArgumentException("Tipo de conexão não suportado")
            };
        }

        /// <summary>
        /// Cria e retorna uma conexão com SQL Server usando LocalDB.
        /// </summary>
        /// <returns>Instância de <see cref="SqlServerConnection"/>.</returns>
        private static IDatabaseConnection GetSqlServerConnection()
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
        private static IDatabaseConnection GetSqliteDatabaseConnection()
        {
            return new SqliteDatabaseConnection(
                $"Data Source={Path.Combine(AppContext.BaseDirectory, "SoftwarePatterns.db")}"
            );
        }
    }
}