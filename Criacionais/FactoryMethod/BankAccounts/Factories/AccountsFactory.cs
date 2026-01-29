using BankAccounts.Accounts;
using BankAccounts.Accounts.Interfaces;

namespace BankAccounts.Factories
{
    /// <summary>
    /// Fábrica de contas bancárias.
    /// Cria instâncias de contas do tipo <see cref="CurrentAccount"/> ou <see cref="SavingsAccount"/>.
    /// </summary>
    public static class AccountsFactory
    {
        /// <summary>
        /// Retorna uma conta do tipo especificado.
        /// </summary>
        /// <param name="tipo">Tipo da conta ("current" ou "savings").</param>
        /// <param name="holder">Titular da conta.</param>
        /// <returns>Instância de <see cref="IAccount"/> correspondente ao tipo informado.</returns>
        /// <exception cref="ArgumentException">Se o tipo informado for inválido.</exception>
        public static IAccount GetAccount(string tipo, Holder holder)
        {
            return tipo.ToLower() switch
            {
                "current" => new CurrentAccount(holder),
                "savings" => new SavingsAccount(holder, depositInterestRate: 0.10, withdrawalInterestRate: 0.02),
                _ => throw new ArgumentException("Tipo de conta inválido", nameof(tipo))
            };
        }
    }
}