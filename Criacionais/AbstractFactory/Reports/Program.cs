using Reports.Factories;
using Reports.Factories.Interfaces;
using Reports.Reports.Interfaces;

namespace Reports
{
    /// <summary>
    /// Classe principal do projeto Reports.
    /// Demonstração de criação e geração de relatórios.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ReportsFactory();

            // Fábricas concretas
            IReportsAbstractFactory pdfFactory = new PdfReportsFactory();
            IReportsAbstractFactory excelFactory = new ExcelReportsFactory();

            // Geração de relatórios PDF
            IPurchaseReport pdfPurchaseReport = factory.GetPurchaseReport(pdfFactory);
            ISalesReport pdfSalesReport = factory.GetSalesReport(pdfFactory);

            pdfPurchaseReport.Generate("Compras.pdf", NodaTime.LocalDate.FromDateTime(DateTime.Today.AddDays(-7)), NodaTime.LocalDate.FromDateTime(DateTime.Today));
            pdfSalesReport.Generate("Vendas.pdf", NodaTime.LocalDate.FromDateTime(DateTime.Today.AddDays(-7)), NodaTime.LocalDate.FromDateTime(DateTime.Today));

            // Geração de relatórios Excel
            IPurchaseReport excelPurchaseReport = factory.GetPurchaseReport(excelFactory);
            ISalesReport excelSalesReport = factory.GetSalesReport(excelFactory);

            excelPurchaseReport.Generate("Compras.xlsx", NodaTime.LocalDate.FromDateTime(DateTime.Today.AddDays(-7)), NodaTime.LocalDate.FromDateTime(DateTime.Today));
            excelSalesReport.Generate("Vendas.xlsx", NodaTime.LocalDate.FromDateTime(DateTime.Today.AddDays(-7)), NodaTime.LocalDate.FromDateTime(DateTime.Today));

            Console.WriteLine("Relatórios gerados com sucesso.");
        }
    }
}