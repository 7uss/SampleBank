using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SampleBank.Models
{
    public enum transactionTypes { deposit, withdraw, innerTransfer, outerTransfer }

    public class Transaction
    {

        public Transaction() {}
        public Transaction(int id, decimal amount, transactionTypes transactionType, bool success, DateTime transactionDate, decimal oldBalance, decimal newBalance, BankAccount bankAccount)
        {
            this.id = id;
            this.amount = amount;
            this.transactionType = transactionType;
            this.success = success;
            this.transactionDate = transactionDate;
            this.oldBalance = oldBalance;
            this.newBalance = newBalance;
            this.bankAccount = bankAccount;
        }

        // the id of the transaction
        public int id { get; set; }

        // the amount of the transaction
        [Precision(4)]
        public decimal amount { get; set; }

        // the type of the transaction (deposit, withdraw, transfer)
        public transactionTypes transactionType { get; set; }

        // whether the transaction was successfull or not
        [DefaultValue(false)]
        public bool success { get; set; }

        // the date the transaction occurred
        public DateTime transactionDate { get; set; }

        [Precision(4)]
        public decimal oldBalance { get; set; }

        [Precision(4)]
        public decimal newBalance { get; set; }

        // this field is the main referencing field for the transaction which means that the transaction occurred on or by this bank account
        public BankAccount bankAccount { get; set; }

        // the account referenced in the column below is the sending end of the transaction
        // which means that its an "outgoing" transaction for the account referenced in this column
        public BankAccount? fromBankAccount { get; set; }

        // the account referenced in the column below is the recieving end of the transaction.
        // which means that its an "incoming" transaction for the account referenced in this column
        public BankAccount? toBankAccount { get; set; }

    }
}