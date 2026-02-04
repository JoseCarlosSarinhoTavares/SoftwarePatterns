using System.Data.SqlClient;

namespace SoftwarePatterns.Creational.AbstractFactory.Authentication.Configuration
{
    public static class SqlServerDB
    {
        /// <summary>
        /// String de conexão com o banco SQL Server.
        /// </summary>
        private static readonly string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=SoftwarePatterns;Trusted_Connection=True;";

        /// <summary>
        /// Cria e abre uma conexão com o banco de dados.
        /// </summary>
        /// <returns>Instância de <see cref="SqlConnection"/> aberta.</returns>
        /// <exception cref="Exception">Lança exceção caso a conexão falhe.</exception>
        public static SqlConnection GetConnection()
        {
            try
            {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha ao conectar no banco de dados", ex);
            }
        }

        /// <summary>
        /// Inicializa a tabela 'Tokens' no banco caso ela não exista e insere registros de exemplo.
        /// </summary>
        public static void Initialize()
        {
            try
            {
                using var conn = GetConnection();

                // Criação da tabela caso não exista
                using (var cmd = new SqlCommand(@"
                    IF OBJECT_ID('dbo.Tokens', 'U') IS NULL
                    BEGIN
                        CREATE TABLE dbo.Tokens (
                            [Token] NVARCHAR(255) NOT NULL
                        )
                    END", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Inserção de 3 registros de exemplo
                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.Tokens (Token) VALUES
                    (@token1),
                    (@token2),
                    (@token3)", conn))
                {
                    cmd.Parameters.AddWithValue("@token1", "123");
                    cmd.Parameters.AddWithValue("@token2", "456");
                    cmd.Parameters.AddWithValue("@token3", "789");

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao inicializar o banco de dados", ex);
            }
        }
    }
}