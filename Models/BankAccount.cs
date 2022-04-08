using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SampleBank.Models
{
    public class BankAccount
    {

        public BankAccount() {}
        public BankAccount(int id, decimal balance, string accountNumber, DateTime expirationDate, string beneficiaryName, string cardNumber, AdvanceUser user)
        {
            this.id = id;
            this.balance = balance;
            this.accountNumber = accountNumber;
            this.expirationDate = expirationDate;
            this.beneficiaryName = beneficiaryName;
            this.cardNumber = cardNumber;
            this.user = user;
        }
        public int id { get; set; }

        [Precision(4)]
        public decimal balance { get; set; }
        public string accountNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime expirationDate { get; set; }
        public string beneficiaryName { get; set; }
        public string cardNumber { get; set; }
        public AdvanceUser user { get; set; }
        public ICollection<Transaction>? transactions { get; set; }
        public ICollection<Transaction>? incomingTransactions { get; set; }
        public ICollection<Transaction>? outgoingTransactions { get; set; }
        public ICollection<AdvanceUser>? beneficiaryUsers { get; set; }

    }
}