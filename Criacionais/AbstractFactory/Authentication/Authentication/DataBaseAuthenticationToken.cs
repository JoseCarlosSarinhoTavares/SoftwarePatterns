using Criacionais.AbstractFactory.Authentication.Authentication.Interfaces;
using Criacionais.AbstractFactory.Authentication.Daos;

namespace Criacionais.AbstractFactory.Authentication.Authentication
{
    /// <summary>
    /// Implementação de autenticação usando tokens armazenados no banco.
    /// </summary>
    public class DataBaseAuthenticationToken : ITokenAuthentication
    {
        /// <summary>
        /// DAO para manipulação dos tokens no banco.
        /// </summary>
        private readonly TokensDao tokensDao;

        /// <summary>
        /// Construtor que recebe o DAO de tokens.
        /// </summary>
        /// <param name="tokensDao">Instância de TokensDao</param>
        public DataBaseAuthenticationToken(TokensDao tokensDao)
        {
            this.tokensDao = tokensDao;
        }

        /// <summary>
        /// Autentica o token verificando se ele existe no banco.
        /// </summary>
        /// <param name="token">Token a ser autenticado</param>
        /// <returns>true se o token for válido, false caso contrário</returns>
        public bool Authenticate(string token)
        {
            // Aqui você pode consultar o banco usando tokensDao
            // Exemplo simples: retorna true se token começa com "token:"
            return tokensDao.ExistsToken(token);
        }
    }
}