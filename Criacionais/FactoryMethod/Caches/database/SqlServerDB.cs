using System.Data.SqlClient;

namespace Caches.Database
{
    /// <summary>
    /// Classe estática que gerencia o cache persistente no SQL Server.
    /// Permite criar a tabela, inserir, consultar, remover e listar dados do cache.
    /// </summary>
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
        /// Inicializa a tabela de cache no banco caso ela não exista.
        /// </summary>
        public static void Initialize()
        {
            try
            {
                using var conn = GetConnection();
                using var cmd = new SqlCommand(@"
                    IF OBJECT_ID('dbo.Cache', 'U') IS NULL
                    BEGIN
                        CREATE TABLE dbo.Cache (
                            [Key] NVARCHAR(200) NOT NULL PRIMARY KEY,
                            [Value] NVARCHAR(MAX) NULL
                        )
                    END", conn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao inicializar o banco de dados", ex);
            }
        }

        /// <summary>
        /// Adiciona ou atualiza um valor no cache.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <param name="value">Valor a ser armazenado.</param>
        public static void PutCache(string key, string value)
        {
            try
            {
                using var conn = GetConnection();
                using var cmd = new SqlCommand(@"
                    MERGE dbo.Cache AS target
                    USING (SELECT @Key AS [Key], @Value AS [Value]) AS source
                    ON target.[Key] = source.[Key]
                    WHEN MATCHED THEN
                        UPDATE SET [Value] = source.[Value]
                    WHEN NOT MATCHED THEN
                        INSERT ([Key], [Value])
                        VALUES (source.[Key], source.[Value]);", conn);

                cmd.Parameters.AddWithValue("@Key", key);
                cmd.Parameters.AddWithValue("@Value", value);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao gravar no cache", ex);
            }
        }

        /// <summary>
        /// Recupera um valor do cache pelo seu identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <returns>Valor armazenado ou null se não existir.</returns>
        public static object GetCache(string key)
        {
            try
            {
                using var conn = GetConnection();
                using var cmd = new SqlCommand(
                    "SELECT [Value] FROM dbo.Cache WHERE [Key] = @Key", conn);

                cmd.Parameters.AddWithValue("@Key", key);
                return cmd.ExecuteScalar() as string;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao ler o cache", ex);
            }
        }

        /// <summary>
        /// Remove um valor do cache pelo seu identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        public static void RemoveCache(string key)
        {
            try
            {
                using var conn = GetConnection();
                using var cmd = new SqlCommand(
                    "DELETE FROM dbo.Cache WHERE [Key] = @Key", conn);

                cmd.Parameters.AddWithValue("@Key", key);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao remover o cache", ex);
            }
        }

        /// <summary>
        /// Retorna todos os registros do cache.
        /// </summary>
        /// <returns>Dicionário com chave e valor de todos os itens do cache.</returns>
        public static Dictionary<string, object> GetAll()
        {
            try
            {
                var data = new Dictionary<string, object>();

                using var conn = GetConnection();
                using var cmd = new SqlCommand(
                    "SELECT [Key], [Value] FROM dbo.Cache", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    data.Add(reader.GetString(0), reader.IsDBNull(1) ? null : reader.GetString(1));

                return data;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar o cache", ex);
            }
        }
    }
}