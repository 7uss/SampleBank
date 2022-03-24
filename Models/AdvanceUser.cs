using Microsoft.AspNetCore.Identity;

namespace SampleBank.Models
{
    public class AdvanceUser : IdentityUser
    {
        public AdvanceUser(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}