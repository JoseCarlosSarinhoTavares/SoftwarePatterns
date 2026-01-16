using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Factories.Interfaces;
using System.Data.Common;

namespace DatabaseAndDaos.Factories
{
    public class SqlServerDaosFactory : IDaosAbstractFactory
    {
        private readonly DbConnection connection;

        public SqlServerDaosFactory(DbConnection connection)
        {
            this.connection = connection;
        }

        public ClientsDao GetClientsDao()
        {
            return new SqlServerClientsDao(connection);
        }

        public ProductsDao GetProductsDao()
        {
            return new SqlServerProductsDao(connection);
        }
    }
}