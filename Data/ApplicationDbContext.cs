using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleBank.Models;

namespace SampleBank.Data;

public class ApplicationDbContext : IdentityDbContext<AdvanceUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        
        builder.Entity<Transaction>().HasOne(b => b.bankAccount).WithMany(t => t.transactions);
        builder.Entity<Transaction>().HasOne(b => b.fromBankAccount).WithMany(t => t.outgoingTransactions);
        builder.Entity<Transaction>().HasOne(b => b.toBankAccount).WithMany(t => t.incomingTransactions);

        builder.Entity<BankAccount>().HasMany(u => u.beneficiaryUsers).WithMany(b => b.beneficiaryAccounts);
        builder.Entity<BankAccount>().HasOne(u => u.user).WithMany(b => b.bankAccounts);
    }

    public DbSet<SampleBank.Models.BankAccount> BankAccount { get; set; }
    public DbSet<SampleBank.Models.Transaction> Transaction { get; set; }
}
