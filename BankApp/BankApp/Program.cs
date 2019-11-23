using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**********Welcome to Bank***********");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all Accounts");

                var option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Thank you for visiting us");
                        return;
                    case 1:
                        Console.Write("Account NAme:");
                        string accountName = Console.ReadLine();
                        Console.Write("Email Address:");
                        string Email = Console.ReadLine();
                        //convert enum to array
                        var AccountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (int i = 0; i < AccountTypes.Length; i++)
                            Console.WriteLine($"{i}. {AccountTypes[i]}");
                        var accounttype = Enum.Parse<TypeOfAccounts>(Console.ReadLine());
                        Console.Write("Initial Deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(accountName,Email, accounttype, amount);
                        break;
                    case 2:
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        var accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNo, amount);
                        Console.WriteLine("Deposit completed successfully");
                        break;
                    case 3:
                        try
                        {
                            PrintAllAccounts();
                            Console.Write("Account Number:");
                            accountNo = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount");
                            amount = Convert.ToDecimal(Console.ReadLine());
                            Bank.Withdraw(accountNo, amount);
                            Console.WriteLine("Withdraw completed successfully");
                        }
                        catch(ArgumentNullException e)
                        {
                            Console.WriteLine($"Error:{e.Message}");
                        }
                        catch(ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine($"Error:{e.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!Please try again!!!!");
                        }
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNo, amount);
                        Console.WriteLine("Withdraw completed successfully");

                        break;
                    case 4:
                        PrintAllAccounts();
                        break;
                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
            }


        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address:");
            string EmailID = Console.ReadLine();
            var accounts = Bank.GetAllAccountsByEmailAddress(EmailID);
            foreach (var MyAccounts in accounts)
            {
                Console.WriteLine($"AN:{MyAccounts.AccountNumber} CD:{MyAccounts.CreatedDate} AT:{MyAccounts.AccountType} Balance :{MyAccounts.Balance} EA:{MyAccounts.EmailAddress}");
            }
        }
    }
}