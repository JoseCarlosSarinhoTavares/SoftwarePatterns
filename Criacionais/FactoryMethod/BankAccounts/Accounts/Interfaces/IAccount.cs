namespace BankAccounts.Accounts.Interfaces
{
    public interface IAccount
    {
        void Deposit(double value);
        void Cashout(double value);
    }
}