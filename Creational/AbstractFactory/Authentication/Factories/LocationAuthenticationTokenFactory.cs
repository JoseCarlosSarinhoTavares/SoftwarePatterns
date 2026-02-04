using SoftwarePatterns.Creational.AbstractFactory.Authentication.Implementations;
using SoftwarePatterns.Creational.AbstractFactory.Authentication.Interfaces;

namespace SoftwarePatterns.Creational.AbstractFactory.Authentication.Factories
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