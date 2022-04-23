using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBank.Data.Migrations
{
    public partial class renameUserBankAccountsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserBeneficiaryAccounts",
                newName: "AdvanceUserBankAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AdvanceUserBankAccount",
                newName: "UserBeneficiaryAccounts");
        }
    }
}
