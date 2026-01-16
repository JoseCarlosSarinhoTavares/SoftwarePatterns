using DatabaseAndDaos.Daos;

namespace DatabaseAndDaos.Factories.Interfaces
{
    public interface IDaosAbstractFactory
    {
        ProductsDao GetProductsDao();
        ClientsDao GetClientsDao();
    }
}