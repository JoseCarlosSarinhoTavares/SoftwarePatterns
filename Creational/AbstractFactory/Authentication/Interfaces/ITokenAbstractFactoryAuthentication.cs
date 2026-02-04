namespace SoftwarePatterns.Creational.AbstractFactory.Authentication.Interfaces
{
    /// <summary>
    /// Contrato para fábricas responsáveis por criar implementações de autenticação de token.
    /// </summary>
    public interface ITokenAbstractFactoryAuthentication
    {
        /// <summary>
        /// Cria e retorna uma implementação de <see cref="ITokenAuthentication"/>.
        /// </summary>
        /// <returns>
        /// Instância de autenticação de token criada pela fábrica.
        /// </returns>
        ITokenAuthentication CreateAuthentication();
    }
}