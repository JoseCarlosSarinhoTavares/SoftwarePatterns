using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Factories.Interfaces;
using System.Data.Common;

namespace DatabaseAndDaos.Factories
{
    public class SqLiteDaosFactory : IDaosAbstractFactory
    {
        private readonly DbConnection connection;

        public SqLiteDaosFactory(DbConnection connection)
        {
            this.connection = connection;
        }

        public ClientsDao GetClientsDao()
        {
            return new SqLiteClientsDao(connection);
        }

        public ProductsDao GetProductsDao()
        {
            return new SqLiteProductsDao(connection);
        }
    }
}