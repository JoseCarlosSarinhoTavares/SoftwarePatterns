namespace SoftwarePatterns.Creational.FactoryMethod.BankAccounts.Interfaces
{
    public interface IAccount
    {
        void Deposit(double value);
        void Cashout(double value);
    }
}