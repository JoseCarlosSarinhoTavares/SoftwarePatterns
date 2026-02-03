using System.Data.SqlClient;

namespace Criacionais.AbstractFactory.Authentication.Daos
{
    /// <summary>
    /// DAO para manipulação de tokens no banco de dados.
    /// </summary>
    public class TokensDao
    {
        private readonly SqlConnection _connection;

        public TokensDao(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Verifica se o token existe na tabela Tokens.
        /// </summary>
        /// <param name="token">Token a ser verificado</param>
        /// <returns>true se o token existir, false caso contrário</returns>
        public bool ExistsToken(string token)
        {
            const string query = "SELECT 1 FROM dbo.Tokens WHERE Token = @token";

            try
            {
                using var cmd = _connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@token", token);

                using var reader = cmd.ExecuteReader();
                return reader.Read(); // retorna true se houver algum registro
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna todos os tokens da tabela Tokens.
        /// </summary>
        /// <returns>Lista de tokens</returns>
        public List<string> GetAll()
        {
            const string query = "SELECT Token FROM dbo.Tokens";
            var tokens = new List<string>();

            try
            {
                using var cmd = _connection.CreateCommand();
                cmd.CommandText = query;

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tokens.Add(reader.GetString(0));
                }

                return tokens;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}