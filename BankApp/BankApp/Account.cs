using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum TypeOfAccounts
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
    class Account
    {
        private static int lastAccountNumber = 0;
        #region Properties
        /// <summary>
        /// Email Addrss of account
        /// </summary>
        public string EmailAddress { get; set; }
        public int AccountNumber { get; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; }
        #endregion



        #region Constructor
        public Account()
        {
            AccountNumber = ++lastAccountNumber;
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

        #endregion
    }
}
