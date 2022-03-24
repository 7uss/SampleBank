using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleBank.Models;

namespace SampleBank.Data;

public class ApplicationDbContext : IdentityDbContext<AdvanceUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<SampleBank.Models.BankAccount> BankAccount { get; set; }
    public DbSet<SampleBank.Models.Transaction> Transaction { get; set; }
}
