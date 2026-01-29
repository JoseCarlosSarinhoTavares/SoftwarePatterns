using Reports.Reports.Interfaces;

namespace Reports.Factories.Interfaces
{
    /// <summary>
    /// Interface da fábrica abstrata de relatórios.
    /// Define métodos para criar diferentes tipos de relatórios sem expor suas implementações concretas.
    /// </summary>
    public interface IReportsAbstractFactory
    {
        /// <summary>
        /// Cria e retorna uma instância de relatório de compras.
        /// </summary>
        /// <returns>Uma instância de <see cref="IPurchaseReport"/>.</returns>
        IPurchaseReport GetPurchaseReport();

        /// <summary>
        /// Cria e retorna uma instância de relatório de vendas.
        /// </summary>
        /// <returns>Uma instância de <see cref="ISalesReport"/>.</returns>
        ISalesReport GetSalesReport();
    }
}