using System.Data.Common;

namespace DatabaseConfiguration
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using DbConnection connection = SqlServerConfiguration.GetInstance().Connect();

                Console.WriteLine(connection.State == System.Data.ConnectionState.Open
                    ? "Conectado no SQL Server"
                    : "Não conectou");

                using DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT 1 + 1 AS RESULT";

                using DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    Console.WriteLine($"Resultado do teste: {reader["RESULT"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar/consultar:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}