using Criacionais.AbstractFactory.Authentication.Authentication;
using Criacionais.AbstractFactory.Authentication.Authentication.Interfaces;
using Criacionais.AbstractFactory.Authentication.Factories.Interfaces;

namespace Criacionais.AbstractFactory.Authentication.Factories
{
    /// <summary>
    /// Fábrica responsável por criar a autenticação de token baseada em validação local.
    /// </summary>
    public class LocationAuthenticationTokenFactory : ITokenAbstractFactoryAuthentication
    {
        /// <summary>
        /// Cria uma instância de <see cref="ITokenAuthentication"/> utilizando a implementação
        /// de autenticação local.
        /// </summary>
        /// <returns>
        /// Implementação de autenticação que valida tokens localmente.
        /// </returns>
        public ITokenAuthentication CreateAuthentication()
        {
            return new LocationAuthenticationToken();
        }
    }
}