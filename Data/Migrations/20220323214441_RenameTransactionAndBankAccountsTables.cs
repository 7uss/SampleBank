using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBank.Data.Migrations
{
    public partial class RenameTransactionAndBankAccountsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("Transaction", "Transactions");
            migrationBuilder.RenameTable("BankAccount", "BankAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("Transactions", "Transaction");
            migrationBuilder.RenameTable("BankAccounts", "BankAccount");
        }
    }
}
