using System.Data.SqlClient;

namespace Caches.Database
{
    public static class SqlServerDB
    {
        private static readonly string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=SoftwarePatterns;Trusted_Connection=True;";

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
                throw new Exception("Database connection failed", ex);
            }
        }

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
                throw new Exception("Error initializing database", ex);
            }
        }

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
                throw new Exception("Error writing cache", ex);
            }
        }

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
                throw new Exception("Error reading cache", ex);
            }
        }

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
                throw new Exception("Error removing cache", ex);
            }
        }

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
                throw new Exception("Error listing cache", ex);
            }
        }
    }
}