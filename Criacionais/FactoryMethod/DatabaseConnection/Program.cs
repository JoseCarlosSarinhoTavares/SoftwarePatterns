using DatabaseConnection.Connections.Factories;
using DatabaseConnection.Connections.Interfaces;
using System.Data.Common;

namespace DatabaseConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Conexão com SqlServer");
            Console.WriteLine("-------------------------------------------------------------------");

            IDbConnection sqlServerConnection = ConnectionsFactory.GetConnection("sqlserver");

            // Poderia estar no DAO, que poderia usar o padrão factory para ser criado
            using DbConnection conn1 = sqlServerConnection.Connect();
            using DbCommand cmd1 = conn1.CreateCommand();

            cmd1.CommandText = "SELECT * FROM Usuarios";

            using DbDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                Console.WriteLine(
                    $"UserName: {reader1["UserName"]} | Email: {reader1["Email"]}"
                );
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Conexão com SqLite");
            Console.WriteLine("-------------------------------------------------------------------");

            IDbConnection sqliteConnection = ConnectionsFactory.GetConnection("sqlite");

            // Poderia estar no DAO, que poderia usar o padrão factory para ser criado
            using DbConnection conn2 = sqliteConnection.Connect();
            using DbCommand cmd2 = conn2.CreateCommand();

            // CRIA A TABELA NO SQLITE
            cmd2.CommandText = """
                CREATE TABLE IF NOT EXISTS Usuarios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
                """;
            cmd2.ExecuteNonQuery();

            // insere dado de teste
            cmd2.CommandText = """
                INSERT INTO Usuarios (UserName, Email)
                SELECT 'teste', 'teste@teste.com'
                WHERE NOT EXISTS (SELECT 1 FROM Usuarios);
                """;
            cmd2.ExecuteNonQuery();

            cmd2.CommandText = "SELECT * FROM Usuarios";
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