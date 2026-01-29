using BankAccounts.Accounts.Interfaces;

namespace BankAccounts.Accounts
{
    /// <summary>
    /// Conta corrente que implementa <see cref="IAccount"/>.
    /// Permite depósitos e saques sem aplicação de juros.
    /// </summary>
    public class CurrentAccount : IAccount
    {
        /// <summary>
        /// Titular da conta.
        /// </summary>
        private Holder _holder;

        /// <summary>
        /// Saldo da conta.
        /// </summary>
        private double _balance;

        /// <summary>
        /// Construtor da conta corrente.
        /// </summary>
        /// <param name="holder">Titular da conta.</param>
        public CurrentAccount(Holder holder) { _holder = holder; }

        /// <summary>
        /// Deposita um valor na conta.
        /// </summary>
        /// <param name="value">Valor a ser depositado.</param>
        public void Deposit(double value)
        {
            _balance += value;
        }

        /// <summary>
        /// Realiza saque da conta se houver saldo suficiente.
        /// </summary>
        /// <param name="value">Valor a ser sacado.</param>
        public void Cashout(double value)
        {
            if (_balance >= value)
                _balance -= value;
        }

        /// <summary>
        /// Retorna uma representação textual da conta.
        /// </summary>
        /// <returns>Informações do titular, número da conta e saldo.</returns>
        public override string ToString()
        {
            return "Conta Corrente: " + _holder.GetAccountNumber() +
                    " | Titular: " + _holder.GetName() +
                    " | Saldo: R$ " + _balance;
        }
    }
}