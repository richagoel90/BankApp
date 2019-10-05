using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of an account==object
            Account account=Bank.CreateAccount("richa.goyal90@gmail.com",
                TypeOfAccounts.Checking, 250);

            Console.WriteLine($"AN:{account.AccountNumber}," +
                $"Balance:{account.Balance:C}," +
                $"AT:{ account.AccountType}," +
                $"CD:{account.CreatedDate}");

            Account account2 = Bank.CreateAccount("test@gmail.com",
                TypeOfAccounts.Savings, 50);

            Console.WriteLine($"AN:{account2.AccountNumber}," +
                $"Balance:{account2.Balance}," +
                $"AT:{ account2.AccountType}," +
                $"CD:{account2.CreatedDate}");

        }
    }
}
