namespace BankApp
{
    static class Bank
    {
        public static Account CreateAccount(
            string emailAddress,
            TypeOfAccounts accountType,
            decimal initialDeposit)
        {
            Account newAccount = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType         
            };
            if (initialDeposit > 0)
            {
                newAccount.Deposit(initialDeposit);
            }
            return newAccount;
        }
    }
}
