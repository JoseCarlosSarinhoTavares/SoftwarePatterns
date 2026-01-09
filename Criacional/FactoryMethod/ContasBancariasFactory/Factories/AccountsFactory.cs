using BankAccounts.Accounts;
using BankAccounts.Accounts.Interfaces;

namespace BankAccounts.Factories
{
    public class AccountsFactory
    {
        public static IAccount GetAccount(string tipo, Holder holder) 
        {
            switch (tipo)
            {
                case "current":
                    return new CurrentAccount(holder);
                case "savings":
                    return new SavingsAccount(holder, depositInterestRate: 0.10, withdrawalInterestRate: 0.02);
                default:
                    throw new ArgumentException("Tipo de conta inválido", nameof(tipo));
            }; 
        }
    }
}