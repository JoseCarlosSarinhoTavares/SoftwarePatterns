using Criacionais.AbstractFactory.Authentication.Authentication.Interfaces;

namespace Criacionais.AbstractFactory.Authentication.Authentication
{
    /// <summary>
    /// Implementação de autenticação de token baseada em validação local.
    /// </summary>
    public class LocationAuthenticationToken : ITokenAuthentication
    {
        /// <summary>
        /// Autentica o token verificando regras locais de validação.
        /// </summary>
        /// <param name="token">Token recebido para validação.</param>
        /// <returns>
        /// true se o token for válido de acordo com a regra local; false caso contrário.
        /// </returns>
        public bool Authenticate(string token)
        {
            if (token == null) return false;

            return token.StartsWith("token:");
        }
    }
}