using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();
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

        public static void Deposit(int accountNumber,decimal amount)
        {
            var account=accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if(account==null)
            {
                //Throw exception
                return;
            }

            account.Deposit(amount);
            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionType = TypeofTransaction.Credit,
                Description = "Bank Deposit",
                Balance = account.Balance,
                AccountNumber = accountNumber

            };
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //Throw exception
                return;
            }

            account.Withdraw(amount);
            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionType = TypeofTransaction.Credit,
                Description = "Bank Deposit",
                Balance = account.Balance,
                AccountNumber = accountNumber

            };
        }

    }
}
