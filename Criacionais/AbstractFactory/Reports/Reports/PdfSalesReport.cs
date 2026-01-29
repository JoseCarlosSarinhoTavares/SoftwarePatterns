using iTextSharp.text;
using iTextSharp.text.pdf;
using NodaTime;
using Reports.Reports.Interfaces;

namespace Reports.Reports
{
    /// <summary>
    /// Implementação de <see cref="ISalesReport"/> que gera relatórios de vendas em PDF.
    /// </summary>
    public class PdfSalesReport : ISalesReport
    {
        /// <summary>
        /// Gera um relatório de vendas em PDF no caminho especificado para o período informado.
        /// </summary>
        /// <param name="path">Caminho do arquivo onde o relatório será salvo.</param>
        /// <param name="startDate">Data de início do período do relatório.</param>
        /// <param name="endDate">Data de término do período do relatório.</param>
        public void Generate(string path, LocalDate startDate, LocalDate endDate)
        {
            try
            {
                using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                using var document = new Document(PageSize.A4);

                PdfWriter.GetInstance(document, stream);

                document.Open();

                document.AddTitle("Relatório de vendas");

                document.Add(new Paragraph($"Período: {startDate:yyyy-MM-dd} até {endDate:yyyy-MM-dd}"));
                document.Add(new Paragraph("Total de vendas: 250,000"));

                document.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}