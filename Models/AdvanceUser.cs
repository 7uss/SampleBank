using Microsoft.AspNetCore.Identity;

namespace SampleBank.Models
{
    public class AdvanceUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ICollection<BankAccount>? bankAccounts { get; set; }
        public ICollection<BankAccount>? beneficiaryAccounts { get; set; }
    }
}