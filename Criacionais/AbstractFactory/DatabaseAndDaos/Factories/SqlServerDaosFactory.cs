using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Factories.Interfaces;
using System.Data.Common;

namespace DatabaseAndDaos.Factories
{
    /// <summary>
    /// Fábrica concreta de DAOs para SQL Server.
    /// Implementa a <see cref="IDaosAbstractFactory"/> e fornece instâncias específicas de DAOs para SQL Server.
    /// </summary>
    public class SqlServerDaosFactory : IDaosAbstractFactory
    {
        private readonly DbConnection connection;

        /// <summary>
        /// Inicializa a fábrica com a conexão ao banco de dados SQL Server.
        /// </summary>
        /// <param name="connection">Conexão de banco de dados a ser usada pelos DAOs.</param>
        public SqlServerDaosFactory(DbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ClientsDao"/> específica para SQL Server.
        /// </summary>
        /// <returns>Uma instância de <see cref="ClientsDao"/>.</returns>
        public ClientsDao GetClientsDao()
        {
            return new SqlServerClientsDao(connection);
        }

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ProductsDao"/> específica para SQL Server.
        /// </summary>
        /// <returns>Uma instância de <see cref="ProductsDao"/>.</returns>
        public ProductsDao GetProductsDao()
        {
            return new SqlServerProductsDao(connection);
        }
    }
}