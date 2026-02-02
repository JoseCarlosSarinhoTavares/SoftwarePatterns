using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DatabaseConfiguration
{
    /// <summary>
    /// Classe responsável por carregar a configuração do SQL Server e criar conexões com o banco.
    /// Implementa o padrão Singleton para garantir uma única instância na aplicação.
    /// </summary>
    public class SqlServerConfiguration
    {
        /// <summary>
        /// String de conexão do SQL Server carregada do appsettings.json.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Instância única (Singleton) criada de forma lazy (sob demanda) e thread-safe.
        /// </summary>
        private static readonly Lazy<SqlServerConfiguration> instance =
            new(() => new SqlServerConfiguration());

        /// <summary>
        /// Construtor privado para impedir instanciação direta.
        /// Carrega a connection string do arquivo appsettings.json.
        /// </summary>
        private SqlServerConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            connectionString = config.GetConnectionString("SqlServer")
                ?? throw new ArgumentException("Connection string 'SqlServer' não encontrada no appsettings.json");
        }

        /// <summary>
        /// Retorna a instância única da configuração do SQL Server.
        /// </summary>
        /// <returns>Instância única de <see cref="SqlServerConfiguration"/>.</returns>
        public static SqlServerConfiguration GetInstance() => instance.Value;

        /// <summary>
        /// Cria e abre uma conexão com o SQL Server usando a connection string carregada.
        /// </summary>
        /// <returns>Conexão aberta do tipo <see cref="DbConnection"/>.</returns>
        public DbConnection Connect()
        {
            DbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}