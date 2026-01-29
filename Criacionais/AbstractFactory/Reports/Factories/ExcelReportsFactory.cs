using Reports.Factories.Interfaces;
using Reports.Reports;
using Reports.Reports.Interfaces;

namespace Reports.Factories
{
    /// <summary>
    /// Fábrica concreta para criação de relatórios em Excel.
    /// Implementa a <see cref="IReportsAbstractFactory"/> fornecendo instâncias de relatórios específicos para Excel.
    /// </summary>
    public class ExcelReportsFactory : IReportsAbstractFactory
    {
        /// <summary>
        /// Cria e retorna uma instância de relatório de compras em Excel.
        /// </summary>
        /// <returns>Uma instância de <see cref="IPurchaseReport"/> que gera relatório em Excel.</returns>
        public IPurchaseReport GetPurchaseReport()
        {
            return new ExcelPurchaseReport();
        }

        /// <summary>
        /// Cria e retorna uma instância de relatório de vendas em Excel.
        /// </summary>
        /// <returns>Uma instância de <see cref="ISalesReport"/> que gera relatório em Excel.</returns>
        public ISalesReport GetSalesReport()
        {
            return new ExcelSalesReport();
        }
    }
}