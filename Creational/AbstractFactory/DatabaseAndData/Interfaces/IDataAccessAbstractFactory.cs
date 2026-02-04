using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Interfaces
{
    /// <summary>
    /// Interface para fábricas abstratas de DataAccess.
    /// Define métodos para criar instâncias de <see cref="ProductsDataAccess"/> e <see cref="ClientsDataAccess"/>.
    /// </summary>
    public interface IDataAccessAbstractFactory
    {
        /// <summary>
        /// Cria e retorna uma instância de <see cref="ProductsDataAccess"/>.
        /// </summary>
        /// <returns>Uma instância de <see cref="ProductsDataAccess"/>.</returns>
        ProductsDataAccess GetProductsDataAccess();

        /// <summary>
        /// Cria e retorna uma instância de <see cref="ClientDataAccess"/>.
        /// </summary>
        /// <returns>Uma instância de <see cref="ClientDataAccess"/>.</returns>
        ClientDataAccess GetClientsDataAccess();
    }
}