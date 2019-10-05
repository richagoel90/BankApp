using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
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
            accounts.Add(newAccount);
            return newAccount;
        }
        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string email)
        {
           return accounts.Where(a => a.EmailAddress == email);
        }
    }
}
