using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public enum TypeOfAccounts
    {
        Checking,
        Savings,
        CD,
        Loan
    }
    //Single Line comment
    /* Double 
     * line 
     * Comment*/
    /// <summary>
    /// This is a bank Account
    /// where a user can deposit 
    /// and withdraw money from Account
    /// </summary>
    public class Account
    {
        #region Properties
        /// <summary>
        /// Email Address of account
        /// </summary>
        public string EmailAddress { get; set; }
        public int AccountNumber { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; private set; }
        public string accountName { get; set; }
        #endregion



        #region Constructor
        public Account()
        {
            CreatedDate = DateTime.Now;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit the balance in your acount
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new ArgumentOutOfRangeException("amount","Insufficient funds!!!");
            Balance -= amount;
        }

        #endregion
    }
}
