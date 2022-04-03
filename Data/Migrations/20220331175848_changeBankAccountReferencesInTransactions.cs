using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBank.Data.Migrations
{
    public partial class changeBankAccountReferencesInTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "toAccountId",
                table: "Transaction",
                newName: "toBankAccountId");

            migrationBuilder.RenameColumn(
                name: "fromAccountId",
                table: "Transaction",
                newName: "fromBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_fromBankAccountId",
                table: "Transaction",
                column: "fromBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_toBankAccountId",
                table: "Transaction",
                column: "toBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_fromBankAccountId",
                table: "Transaction",
                column: "fromBankAccountId",
                principalTable: "BankAccount",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_toBankAccountId",
                table: "Transaction",
                column: "toBankAccountId",
                principalTable: "BankAccount",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_fromBankAccountId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_toBankAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_fromBankAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_toBankAccountId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "toBankAccountId",
                table: "Transaction",
                newName: "toAccountId");

            migrationBuilder.RenameColumn(
                name: "fromBankAccountId",
                table: "Transaction",
                newName: "fromAccountId");
        }
    }
}
