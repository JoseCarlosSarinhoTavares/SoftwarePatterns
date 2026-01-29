using NodaTime;
using OfficeOpenXml;
using Reports.Reports.Interfaces;

namespace Reports.Reports
{
    /// <summary>
    /// Implementação de <see cref="ISalesReport"/> que gera relatórios de vendas em Excel.
    /// </summary>
    public class ExcelSalesReport : ISalesReport
    {
        /// <summary>
        /// Gera um relatório de vendas no caminho especificado para o período informado.
        /// </summary>
        /// <param name="path">Caminho do arquivo onde o relatório será salvo.</param>
        /// <param name="startDate">Data de início do período do relatório.</param>
        /// <param name="endDate">Data de término do período do relatório.</param>
        public void Generate(string path, LocalDate startDate, LocalDate endDate)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Carlos");

                var file = new FileInfo(path);
                if (file.Directory != null && !file.Directory.Exists)
                    file.Directory.Create();

                using var package = new ExcelPackage();
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.Add("vendas");

                // Header
                worksheet.Cells["A1"].Value = "Relatório de vendas";
                worksheet.Cells["A2"].Value = $"Período: {startDate:yyyy-MM-dd} até {endDate:yyyy-MM-dd}";

                // Columns
                worksheet.Cells["A4"].Value = "Data";
                worksheet.Cells["B4"].Value = "Fornecedor";
                worksheet.Cells["C4"].Value = "Descrição";
                worksheet.Cells["D4"].Value = "Montante";

                // Sample data
                worksheet.Cells["A5"].Value = startDate.ToString("yyyy-MM-dd", null);
                worksheet.Cells["B5"].Value = "Fornecedor A";
                worksheet.Cells["C5"].Value = "Material de escritório";
                worksheet.Cells["D5"].Value = 150.75;

                worksheet.Cells["A6"].Value = endDate.ToString("yyyy-MM-dd", null);
                worksheet.Cells["B6"].Value = "Fornecedor B";
                worksheet.Cells["C6"].Value = "Hardware";
                worksheet.Cells["D6"].Value = 320.00;

                // Format
                worksheet.Cells["A4:D4"].Style.Font.Bold = true;
                worksheet.Cells["D5:D1000"].Style.Numberformat.Format = "#,##0.00";
                worksheet.Cells.AutoFitColumns();

                package.SaveAs(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}