using System.Data.Common;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Interfaces;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Factories
{
    /// <summary>
    /// Fábrica concreta de DataAccess para SQLite.
    /// Implementa a <see cref="IDataAccessAbstractFactory"/> e fornece instâncias específicas de DataAccess para SQLite.
    /// </summary>
    public class SqLiteDataAccessFactory : IDataAccessAbstractFactory
    {
        private readonly DbConnection connection;

        /// <summary>
        /// Inicializa a fábrica com a conexão ao banco de dados SQLite.
        /// </summary>
        /// <param name="connection">Conexão de banco de dados a ser usada pelos DataAccess.</param>
        public SqLiteDataAccessFactory(DbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ClientDataAccess"/> específica para SQLite.
        /// </summary>
        /// <returns>Uma instância de <see cref="ClientDataAccess"/>.</returns>
        public ClientDataAccess GetClientsDataAccess()
        {
            return new SqLiteClientsDataAccess(connection);
        }

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ProductsDataAccess"/> específica para SQLite.
        /// </summary>
        /// <returns>Uma instância de <see cref="ProductsDataAccess"/>.</returns>
        public ProductsDataAccess GetProductsDataAccess()
        {
            return new SqLiteProductsDataAccess(connection);
        }
    }
}