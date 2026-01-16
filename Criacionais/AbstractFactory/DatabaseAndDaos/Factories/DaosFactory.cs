using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Factories.Interfaces;

namespace DatabaseAndDaos.Factories
{
    public class DaosFactory
    {
        public static ProductsDao GetProductsDao(IDaosAbstractFactory factory) { return factory.GetProductsDao(); }
        public static ClientsDao GetClientsDao(IDaosAbstractFactory factory) { return factory.GetClientsDao(); }
    }
}