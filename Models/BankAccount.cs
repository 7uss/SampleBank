using System.ComponentModel.DataAnnotations;

namespace SampleBank.Models
{
    public class BankAccount
    {
        
        public BankAccount(){}
        public BankAccount(int id, string accountNumber, DateTime expirationDate, string beneficiaryName, string cardNumber){
            
            this.id = id;
            this.accountNumber = accountNumber;
            this.expirationDate = expirationDate;
            this.beneficiaryName = beneficiaryName;
            this.cardNumber = cardNumber;

        }
        public int id { get; set; }
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