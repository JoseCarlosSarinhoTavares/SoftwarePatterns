using NodaTime;

namespace Reports.Reports.Interfaces
{
    /// <summary>
    /// Interface para relatórios de vendas.
    /// Define o método para gerar relatórios de vendas em diferentes formatos.
    /// </summary>
    public interface ISalesReport
    {
        /// <summary>
        /// Gera um relatório de vendas no caminho especificado para o período informado.
        /// </summary>
        /// <param name="path">Caminho do arquivo onde o relatório será salvo.</param>
        /// <param name="startDate">Data de início do período do relatório.</param>
        /// <param name="endDate">Data de término do período do relatório.</param>
        void Generate(string path, LocalDate startDate, LocalDate endDate);
    }
}