using Reports.Factories.Interfaces;
using Reports.Reports.Interfaces;
using Reports.Reports;

namespace Reports.Factories
{
    /// <summary>
    /// Fábrica concreta para criação de relatórios em PDF.
    /// Implementa a <see cref="IReportsAbstractFactory"/> fornecendo instâncias de relatórios específicos para PDF.
    /// </summary>
    public class PdfReportsFactory : IReportsAbstractFactory
    {
        /// <summary>
        /// Cria e retorna uma instância de relatório de compras em PDF.
        /// </summary>
        /// <returns>Uma instância de <see cref="IPurchaseReport"/> que gera relatório em PDF.</returns>
        public IPurchaseReport GetPurchaseReport()
        {
            return new PdfPurchaseReport();
        }

        /// <summary>
        /// Cria e retorna uma instância de relatório de vendas em PDF.
        /// </summary>
        /// <returns>Uma instância de <see cref="ISalesReport"/> que gera relatório em PDF.</returns>
        public ISalesReport GetSalesReport()
        {
            return new PdfSalesReport();
        }
    }
}