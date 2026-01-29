using Reports.Reports.Interfaces;
using Reports.Factories.Interfaces;

namespace Reports.Factories
{
    /// <summary>
    /// Classe fábrica para criar instâncias de relatórios usando uma fábrica abstrata.
    /// Implementa o padrão de projeto Abstract Factory.
    /// </summary>
    public class ReportsFactory
    {
        /// <summary>
        /// Cria um relatório de compras usando a fábrica abstrata fornecida.
        /// </summary>
        /// <param name="factory">Fábrica abstrata que sabe como criar relatórios.</param>
        /// <returns>Uma instância de <see cref="IPurchaseReport"/>.</returns>
        public IPurchaseReport GetPurchaseReport(IReportsAbstractFactory factory)
        {
            return factory.GetPurchaseReport();
        }

        /// <summary>
        /// Cria um relatório de vendas usando a fábrica abstrata fornecida.
        /// </summary>
        /// <param name="factory">Fábrica abstrata que sabe como criar relatórios.</param>
        /// <returns>Uma instância de <see cref="ISalesReport"/>.</returns>
        public ISalesReport GetSalesReport(IReportsAbstractFactory factory)
        {
            return factory.GetSalesReport();
        }
    }
}