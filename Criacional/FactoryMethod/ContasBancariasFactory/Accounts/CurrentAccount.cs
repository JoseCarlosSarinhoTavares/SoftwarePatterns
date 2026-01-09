using BankAccounts.Accounts.Interfaces;

namespace BankAccounts.Accounts
{
    public class CurrentAccount : IAccount
    {
        private Holder _holder;
        private double _balance;

        public CurrentAccount(Holder holder) { _holder = holder; }

        public void Deposit(double value)
        {
            _balance += value;
        }

        public void Cashout(double value)
        {
            if (_balance >= value)
                _balance -= value;
        }

        public override string ToString()
        {
            return "Conta Corrente: " + _holder.GetAccountNumber() +
                    " | Titular: " + _holder.GetName() +
                    " | Saldo: R$ " + _balance;
        }
    }
}