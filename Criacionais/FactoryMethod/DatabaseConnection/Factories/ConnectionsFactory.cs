using DatabaseConnection.Connections;
using DatabaseConnection.Connections.Interfaces;

namespace DatabaseConnection.Factories
{
    public class ConnectionsFactory
    {
        public static IDbConnection GetConnection(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo de conexão inválido");

            switch (tipo.ToLower())
            {
                case "sqlserver":
                    return GetSQLServerConnection();

                case "sqlite":
                    return GetSQLiteConnection();

                default:
                    throw new ArgumentException("Tipo de conexão não suportado");
            }
        }

        private static IDbConnection GetSQLServerConnection()
        {
            return new SqlServerConnection(
                "Server=(localdb)\\mssqllocaldb;Database=SGI;"
            );
        }

        private static IDbConnection GetSQLiteConnection()
        {
            return new SQLiteConnection(
                $"Data Source={Path.Combine(AppContext.BaseDirectory, "TESTE.db")}"
            );
        }
    }
}