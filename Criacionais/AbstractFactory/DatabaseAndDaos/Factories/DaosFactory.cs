using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Factories.Interfaces;

namespace DatabaseAndDaos.Factories
{
    /// <summary>
    /// Fábrica abstrata de acesso rápido a DAOs.
    /// Permite obter instâncias de <see cref="ProductsDao"/> e <see cref="ClientsDao"/>
    /// a partir de uma fábrica concreta (<see cref="IDaosAbstractFactory"/>).
    /// </summary>
    public class DaosFactory
    {
        /// <summary>
        /// Obtém uma instância de <see cref="ProductsDao"/> usando a fábrica fornecida.
        /// </summary>
        /// <param name="factory">Fábrica concreta de DAOs.</param>
        /// <returns>Uma instância de <see cref="ProductsDao"/>.</returns>
        public static ProductsDao GetProductsDao(IDaosAbstractFactory factory)
        {
            return factory.GetProductsDao();
        }

        /// <summary>
        /// Obtém uma instância de <see cref="ClientsDao"/> usando a fábrica fornecida.
        /// </summary>
        /// <param name="factory">Fábrica concreta de DAOs.</param>
        /// <returns>Uma instância de <see cref="ClientsDao"/>.</returns>
        public static ClientsDao GetClientsDao(IDaosAbstractFactory factory)
        {
            return factory.GetClientsDao();
        }
    }
}