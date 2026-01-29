using BankAccounts.Accounts;
using BankAccounts.Accounts.Interfaces;
using BankAccounts.Factories;

namespace BankAccounts
{
    /// <summary>
    /// Aplicação de exemplo que demonstra o uso do Factory Method
    /// para criar contas correntes e poupança e realizar operações básicas.
    /// </summary>
    public class FactoryMethodApp
    {
        /// <summary>
        /// Ponto de entrada da aplicação.
        /// </summary>
        public static void Main(string[] args)
        {
            string _accountNumber, _holderName;
            double _valueDeposit = 100.0, _valueWithdrawal = 50.0;

            // Demonstração Conta Corrente
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Conta Corrente");
            Console.WriteLine("-------------------------------------------------------------------");

            _accountNumber = "CC001";
            _holderName = "Carlos Tavares";
            IAccount currentAccount = AccountsFactory.GetAccount("current", new Holder(_accountNumber, _holderName));
            Console.WriteLine(currentAccount);
            Console.WriteLine();

            Console.WriteLine("- Depósito: R$ " + _valueDeposit);
            currentAccount.Deposit(_valueDeposit);
            Console.WriteLine(currentAccount);
            Console.WriteLine();

            Console.WriteLine("- Saque: R$ " + _valueWithdrawal);
            currentAccount.Cashout(_valueWithdrawal);
            Console.WriteLine(currentAccount);

            // Demonstração Conta Poupança
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Conta Poupança");
            Console.WriteLine("-------------------------------------------------------------------");

            _accountNumber = "CP002";
            _holderName = "Ketoly Cheine";
            IAccount savingsAccount = AccountsFactory.GetAccount("savings", new Holder(_accountNumber, _holderName));
            Console.WriteLine(savingsAccount);
            Console.WriteLine();

            Console.WriteLine("- Depósito: R$ " + _valueDeposit);
            savingsAccount.Deposit(_valueDeposit);
            Console.WriteLine(savingsAccount);
            Console.WriteLine();

            Console.WriteLine("- Saque: R$ " + _valueWithdrawal);
            savingsAccount.Cashout(_valueWithdrawal);
            Console.WriteLine(savingsAccount);

            // Exemplo de uso de tipo inválido
            // AccountsFactory.GetAccount("teste", null);
        }
    }
}