using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Interfaces;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Factories
{
    /// <summary>
    /// Fábrica abstrata de acesso rápido a DataAccess.
    /// Permite obter instâncias de <see cref="ProductsDataAccess"/> e <see cref="ClientDataAccess"/>
    /// a partir de uma fábrica concreta (<see cref="IDataAccessAbstractFactory"/>).
    /// </summary>
    public class DataAccessFactory
    {
        /// <summary>
        /// Obtém uma instância de <see cref="ProductsDataAccess"/> usando a fábrica fornecida.
        /// </summary>
        /// <param name="factory">Fábrica concreta de DAOs.</param>
        /// <returns>Uma instância de <see cref="ProductsDataAccess"/>.</returns>
        public static ProductsDataAccess GetProductsDataAccess(IDataAccessAbstractFactory factory)
        {
            return factory.GetProductsDataAccess();
        }

        /// <summary>
        /// Obtém uma instância de <see cref="ClientDataAccess"/> usando a fábrica fornecida.
        /// </summary>
        /// <param name="factory">Fábrica concreta de DAOs.</param>
        /// <returns>Uma instância de <see cref="ClientDataAccess"/>.</returns>
        public static ClientDataAccess GetClientsDataAccess(IDataAccessAbstractFactory factory)
        {
            return factory.GetClientsDataAccess();
        }
    }
}