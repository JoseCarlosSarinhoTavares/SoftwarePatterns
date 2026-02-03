using Criacionais.AbstractFactory.Authentication.Authentication;
using Criacionais.AbstractFactory.Authentication.Authentication.Interfaces;
using Criacionais.AbstractFactory.Authentication.Configuration;
using Criacionais.AbstractFactory.Authentication.Daos;
using Criacionais.AbstractFactory.Authentication.Factories.Interfaces;

namespace Criacionais.AbstractFactory.Authentication.Factories
{
    /// <summary>
    /// Fábrica responsável por criar a autenticação de token baseada em banco de dados.
    /// </summary>
    public class DataBaseAuthenticationTokenFactory : ITokenAbstractFactoryAuthentication
    {
        /// <summary>
        /// Cria uma instância de <see cref="ITokenAuthentication"/> utilizando uma implementação
        /// que consulta tokens armazenados no SQL Server.
        /// </summary>
        /// <returns>
        /// Implementação de autenticação configurada para validar tokens no banco.
        /// </returns>
        public ITokenAuthentication CreateAuthentication()
        {
            return new DataBaseAuthenticationToken(
                new TokensDao(SqlServerDB.GetConnection())
            );
        }
    }
}