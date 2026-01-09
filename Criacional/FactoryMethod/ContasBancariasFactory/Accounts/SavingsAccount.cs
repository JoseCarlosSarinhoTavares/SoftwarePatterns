using BankAccounts.Accounts.Interfaces;

namespace BankAccounts.Accounts
{
    public class SavingsAccount : IAccount
    {
        private Holder _holder;
        private double _balance;
        private double _depositInterestRate;
        private double _withdrawalInterestRate;

        public SavingsAccount(Holder holder, double depositInterestRate, double withdrawalInterestRate) 
        {
            _holder = holder;
            _depositInterestRate = depositInterestRate;
            _withdrawalInterestRate = withdrawalInterestRate;
        }

        public void Deposit(double value)
        {
            double valueComJuros = value + value * _depositInterestRate;
            _balance += valueComJuros;
        }

        public void Cashout(double value)
        {
            double valueComJuros = value + value * _withdrawalInterestRate;
            if (_balance >= valueComJuros)
                _balance -= valueComJuros;
        }

        public override string ToString()
        {
            return "Conta Poupança: " + _holder.GetAccountNumber() +
                    " | Titular: " + _holder.GetName() +
                    " | Saldo: R$ " + _balance;
        }
    }
}