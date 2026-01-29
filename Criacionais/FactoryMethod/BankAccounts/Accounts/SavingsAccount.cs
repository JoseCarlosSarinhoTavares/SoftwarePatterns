using BankAccounts.Accounts.Interfaces;

namespace BankAccounts.Accounts
{
    /// <summary>
    /// Conta Poupança.
    /// Implementa <see cref="IAccount"/> e aplica juros sobre depósitos e saques.
    /// </summary>
    public class SavingsAccount : IAccount
    {
        private readonly Holder _holder;
        private double _balance;
        private readonly double _depositInterestRate;
        private readonly double _withdrawalInterestRate;

        /// <summary>
        /// Construtor da conta poupança.
        /// </summary>
        /// <param name="holder">Titular da conta.</param>
        /// <param name="depositInterestRate">Taxa de juros aplicada aos depósitos (ex: 0.10 = 10%).</param>
        /// <param name="withdrawalInterestRate">Taxa de juros aplicada aos saques (ex: 0.02 = 2%).</param>
        public SavingsAccount(Holder holder, double depositInterestRate, double withdrawalInterestRate)
        {
            _holder = holder;
            _depositInterestRate = depositInterestRate;
            _withdrawalInterestRate = withdrawalInterestRate;
        }

        /// <summary>
        /// Deposita um valor na conta, aplicando a taxa de juros de depósito.
        /// </summary>
        /// <param name="value">Valor a ser depositado.</param>
        public void Deposit(double value)
        {
            double valueComJuros = value + value * _depositInterestRate;
            _balance += valueComJuros;
        }

        /// <summary>
        /// Realiza saque da conta, aplicando a taxa de juros de saque.
        /// </summary>
        /// <param name="value">Valor a ser sacado.</param>
        public void Cashout(double value)
        {
            double valueComJuros = value + value * _withdrawalInterestRate;
            if (_balance >= valueComJuros)
            {
                _balance -= valueComJuros;
            }
        }

        /// <summary>
        /// Retorna uma representação textual da conta.
        /// </summary>
        /// <returns>String com informações do titular, número da conta e saldo.</returns>
        public override string ToString()
        {
            return $"Conta Poupança: {_holder.GetAccountNumber()} | Titular: {_holder.GetName()} | Saldo: R$ {_balance:F2}";
        }
    }
}