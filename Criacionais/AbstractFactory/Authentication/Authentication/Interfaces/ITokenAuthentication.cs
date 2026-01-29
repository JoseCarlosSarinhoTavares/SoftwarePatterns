namespace Authentication.Authentication.Interfaces
{
    /// <summary>
    /// Contrato para autenticação baseada em token.
    /// </summary>
    public interface ITokenAuthentication
    {
        /// <summary>
        /// Valida se o token informado é autenticado/aceito pela implementação.
        /// </summary>
        /// <param name="token">Token que será validado.</param>
        /// <returns>
        /// true se o token for considerado válido; false caso contrário.
        /// </returns>
        bool Authenticate(string token);
    }
}