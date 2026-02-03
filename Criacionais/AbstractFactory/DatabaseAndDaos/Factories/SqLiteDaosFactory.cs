using System.Data.Common;
using Criacionais.AbstractFactory.DatabaseAndDaos.Daos;
using Criacionais.AbstractFactory.DatabaseAndDaos.Factories.Interfaces;

namespace Criacionais.AbstractFactory.DatabaseAndDaos.Factories
{
    /// <summary>
    /// Fábrica concreta de DAOs para SQLite.
    /// Implementa a <see cref="IDaosAbstractFactory"/> e fornece instâncias específicas de DAOs para SQLite.
    /// </summary>
    public class SqLiteDaosFactory : IDaosAbstractFactory
    {
        private readonly DbConnection connection;

        /// <summary>
        /// Inicializa a fábrica com a conexão ao banco de dados SQLite.
        /// </summary>
        /// <param name="connection">Conexão de banco de dados a ser usada pelos DAOs.</param>
        public SqLiteDaosFactory(DbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ClientsDao"/> específica para SQLite.
        /// </summary>
        /// <returns>Uma instância de <see cref="ClientsDao"/>.</returns>
        public ClientsDao GetClientsDao()
        {
            return new SqLiteClientsDao(connection);
        }

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ProductsDao"/> específica para SQLite.
        /// </summary>
        /// <returns>Uma instância de <see cref="ProductsDao"/>.</returns>
        public ProductsDao GetProductsDao()
        {
            return new SqLiteProductsDao(connection);
        }
    }
}