using iTextSharp.text.pdf;
using iTextSharp.text;
using NodaTime;
using Reports.Reports.Interfaces;

namespace Reports.Reports
{
    /// <summary>
    /// Implementação de <see cref="IPurchaseReport"/> que gera relatórios de compras em PDF.
    /// </summary>
    public class PdfPurchaseReport : IPurchaseReport
    {
        /// <summary>
        /// Gera um relatório de compras em PDF no caminho especificado para o período informado.
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

                document.AddTitle("Relatório de compras");

                document.Add(new Paragraph($"Período: {startDate:yyyy-MM-dd} até {endDate:yyyy-MM-dd}"));
                document.Add(new Paragraph("Total de compras: 390,000"));

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