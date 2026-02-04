using SoftwarePatterns.Creational.AbstractFactory.Authentication.Configuration;
using SoftwarePatterns.Creational.AbstractFactory.Authentication.Data;
using SoftwarePatterns.Creational.AbstractFactory.Authentication.Implementations;
using SoftwarePatterns.Creational.AbstractFactory.Authentication.Interfaces;

namespace SoftwarePatterns.Creational.AbstractFactory.Authentication.Factories
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
                new TokensDataAccess(SqlServerDB.GetConnection())
            );
        }
    }
}