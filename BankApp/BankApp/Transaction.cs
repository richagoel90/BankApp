using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum TypeofTransaction
    {
        Credit,
        Debit
    }
    class Transaction
    {
        #region Properties
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TypeofTransaction TransactionType { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber{ get; set; }
        public virtual Account Account { get; set; }
        #endregion
    }
}
