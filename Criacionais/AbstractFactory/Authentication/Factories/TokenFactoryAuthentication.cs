using Criacionais.AbstractFactory.Authentication.Authentication.Interfaces;
using Criacionais.AbstractFactory.Authentication.Factories.Interfaces;

namespace Criacionais.AbstractFactory.Authentication.Factories
{
    /// <summary>
    /// Classe responsável por delegar a criação da autenticação para uma fábrica.
    /// </summary>
    public class TokenFactoryAuthentication
    {
        /// <summary>
        /// Cria uma implementação de autenticação de token usando a fábrica informada.
        /// </summary>
        /// <param name="factory">Fábrica responsável por criar a autenticação</param>
        /// <returns>Implementação de autenticação de token</returns>
        public static ITokenAuthentication CreateAuthentication(ITokenAbstractFactoryAuthentication factory)
        {
            return factory.CreateAuthentication();
        }
    }
}