using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("**********Welcome to Bank***********");
            while(true)
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
                        Console.Write("Email Address:");
                        string Email = Console.ReadLine();
                        //convert enum to array
                        var AccountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (int i = 0; i < AccountTypes.Length; i++)
                            Console.WriteLine($"{i}. {AccountTypes[i]}");
                        var accounttype = Enum.Parse<TypeOfAccounts>(Console.ReadLine());
                        Console.Write("Initial Deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(Email, accounttype, amount);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
            }
            

        }
    }
}
