using Authentication.Authentication.Interfaces;
using Authentication.Factories.Interfaces;

namespace Authentication.Factories
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