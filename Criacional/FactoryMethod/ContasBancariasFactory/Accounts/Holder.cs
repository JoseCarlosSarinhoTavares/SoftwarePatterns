namespace BankAccounts.Accounts
{
    public class Holder
    {
        private string _accountNumber;
        private string _name;

        public Holder(string accountNumber, string name)
        {
            _accountNumber = accountNumber;
            _name = name;
        }

        public string GetAccountNumber() { return _accountNumber; }
        public void SetAccountNumber(string accountNumber) { _accountNumber = accountNumber; }
        public string GetName() { return _name; }
        public void SetName(string name) { _name = name; }
    }
}