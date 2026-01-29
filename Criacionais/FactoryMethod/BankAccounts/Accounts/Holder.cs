namespace BankAccounts.Accounts
{
    /// <summary>
    /// Representa o titular de uma conta bancária.
    /// </summary>
    public class Holder
    {
        /// <summary>
        /// Número da conta do titular.
        /// </summary>
        private string _accountNumber;

        /// <summary>
        /// Nome do titular da conta.
        /// </summary>
        private string _name;

        /// <summary>
        /// Construtor da classe <see cref="Holder"/>.
        /// </summary>
        /// <param name="accountNumber">Número da conta do titular.</param>
        /// <param name="name">Nome do titular.</param>
        public Holder(string accountNumber, string name)
        {
            _accountNumber = accountNumber;
            _name = name;
        }

        /// <summary>
        /// Obtém o número da conta.
        /// </summary>
        /// <returns>Número da conta do titular.</returns>
        public string GetAccountNumber() { return _accountNumber; }

        /// <summary>
        /// Define o número da conta.
        /// </summary>
        /// <param name="accountNumber">Novo número da conta.</param>
        public void SetAccountNumber(string accountNumber) { _accountNumber = accountNumber; }

        /// <summary>
        /// Obtém o nome do titular.
        /// </summary>
        /// <returns>Nome do titular.</returns>
        public string GetName() { return _name; }

        /// <summary>
        /// Define o nome do titular.
        /// </summary>
        /// <param name="name">Novo nome do titular.</param>
        public void SetName(string name) { _name = name; }
    }
}