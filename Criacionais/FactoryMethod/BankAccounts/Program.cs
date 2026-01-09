using BankAccounts.Accounts;
using BankAccounts.Accounts.Interfaces;
using BankAccounts.Factories;

namespace BankAccounts
{
    public class FactoryMethodApp
    {
        public static void Main(string[] args)
        {
            string _accountNumber, _holderName;
            double _valueDeposit = 100.0, _valueWithdrawal = 50.0;

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

            //AccountsFactory.GetAccount("teste", null);
        }
    }
}