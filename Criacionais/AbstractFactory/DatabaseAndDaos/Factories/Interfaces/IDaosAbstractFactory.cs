using DatabaseAndDaos.Daos;

namespace DatabaseAndDaos.Factories.Interfaces
{
    /// <summary>
    /// Interface para fábricas abstratas de DAOs.
    /// Define métodos para criar instâncias de <see cref="ProductsDao"/> e <see cref="ClientsDao"/>.
    /// </summary>
    public interface IDaosAbstractFactory
    {
        /// <summary>
        /// Cria e retorna uma instância de <see cref="ProductsDao"/>.
        /// </summary>
        /// <returns>Uma instância de <see cref="ProductsDao"/>.</returns>
        ProductsDao GetProductsDao();

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ClientsDao"/>.
        /// </summary>
        /// <returns>Uma instância de <see cref="ClientsDao"/>.</returns>
        ClientsDao GetClientsDao();
    }
}