using System.ComponentModel.DataAnnotations;

namespace SampleBank.Models
{ 
    public class BankAccount
    {
        public BankAccount(){}
        
        public BankAccount(int id, string accountNumber, DateTime expirationDate, string beneficiaryName, string cardNumber)
        {
            this.Id = id;
            this.AccountNumber = accountNumber;
            this.ExpirationDate = expirationDate;
            this.BeneficiaryName = beneficiaryName;
            this.CardNumber = cardNumber;

        }
        public int Id { get; set; }
        public string AccountNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public string BeneficiaryName { get; set; }

        public string CardNumber { get; set; }

        public AdvanceUser User { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}