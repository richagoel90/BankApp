using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    public static class Bank
    {
        
        private static BankContext db = new BankContext();
        public static Account CreateAccount(
            string accountName,
            string emailAddress,
            TypeOfAccounts accountType,
            decimal initialDeposit=0)
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
            db.Accounts.Add(newAccount);
            db.SaveChanges();
            return newAccount;
        }
        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("email address","Email address is not correct");
           return db.Accounts.Where(a => a.EmailAddress == email);
        }
        public static IEnumerable<Transaction> GetAllTransactionsByAccountNumber(int AccountNo)
        {
            return db.Transactions.Where(a => a.AccountNumber == AccountNo).OrderByDescending(a=>a.TransactionDate);
        }
        public static Account GetAccountByAccountNumber(int AccountNo)
        {
            return db.Accounts.Find(AccountNo);
        }

        public static void UpdateAccount(Account updatedAccount)
        {
            var oldAccount = GetAccountByAccountNumber(updatedAccount.AccountNumber);
            oldAccount.EmailAddress = updatedAccount.EmailAddress;
            oldAccount.AccountType = updatedAccount.AccountType;
            oldAccount.accountName = updatedAccount.accountName;
            db.SaveChanges();

        }
        public static void Deposit(int accountNumber,decimal amount)
        {
            var account=db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if(account==null)
            {
                //Throw exception
                return;
                string a;
                string[] s=a.Split(' ');
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
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
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
                TransactionType = TypeofTransaction.Debit,
                Description = "Bank Deposit",
                Balance = account.Balance,
                AccountNumber = accountNumber

            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

    }
}
