using DatabaseConnection.Connections.Interfaces;
using DatabaseConnection.Factories;
using System.Data.Common;

namespace DatabaseConnection
{
    /// <summary>
    /// Demonstração do uso das conexões SQL Server e SQLite usando o padrão Factory.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // --------------------- SQL Server ---------------------
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Conexão com SqlServer");
            Console.WriteLine("-------------------------------------------------------------------");

            // Obtem conexão via factory
            IDbConnection sqlServerConnection = ConnectionsFactory.GetConnection("sqlserver");

            // Usa a conexão em bloco using para garantir o Dispose
            using DbConnection conn1 = sqlServerConnection.Connect();
            using DbCommand cmd1 = conn1.CreateCommand();

            // Consulta de exemplo
            cmd1.CommandText = "SELECT * FROM Users";
            using DbDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                Console.WriteLine(
                    $"UserName: {reader1["UserName"]} | Email: {reader1["Email"]}"
                );
            }

            // --------------------- SQLite ---------------------
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Conexão com SqLite");
            Console.WriteLine("-------------------------------------------------------------------");

            // Obtem conexão via factory
            IDbConnection sqliteConnection = ConnectionsFactory.GetConnection("sqlite");

            // Usa a conexão em bloco using para garantir o Dispose
            using DbConnection conn2 = sqliteConnection.Connect();
            using DbCommand cmd2 = conn2.CreateCommand();

            // Cria tabela Users se não existir
            cmd2.CommandText = """
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
            """;
            cmd2.ExecuteNonQuery();

            // Insere dado de teste se tabela estiver vazia
            cmd2.CommandText = """
                INSERT INTO Users (UserName, Email)
                SELECT 'teste', 'teste@teste.com'
                WHERE NOT EXISTS (SELECT 1 FROM Users);
            """;
            cmd2.ExecuteNonQuery();

            // Consulta e exibe os dados
            cmd2.CommandText = "SELECT * FROM Users";
            using DbDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                Console.WriteLine(
                    $"UserName: {reader2["UserName"]} | Email: {reader2["Email"]}"
                );
            }
        }
    }
}