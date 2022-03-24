using System.ComponentModel;

namespace SampleBank.Models
{
    public enum TransactionTypes { deposit, withdraw, transfer }
    public class Transaction
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public TransactionTypes TransactionType { get; set; }

        [DefaultValue(false)]
        public bool Success { get; set; }
        public DateTime Date { get; set; }
        public BankAccount BankAccount { get; set; }
        public int? FromAccountId { get; set; }
        public int? ToAccountId { get; set; }

    }
}