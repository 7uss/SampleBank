using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBank.Data.Migrations
{
    public partial class camelCaseTableDataFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_UserId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "BankAccount",
                newName: "BankAccount");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "AspNetUsers",
                newName: "dateOfBirth");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transaction",
                newName: "transactionType");

            migrationBuilder.RenameColumn(
                name: "ToAccountId",
                table: "Transaction",
                newName: "toAccountId");

            migrationBuilder.RenameColumn(
                name: "Success",
                table: "Transaction",
                newName: "success");

            migrationBuilder.RenameColumn(
                name: "FromAccountId",
                table: "Transaction",
                newName: "fromAccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "Transaction",
                newName: "bankAccountid");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transaction",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transaction",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transaction",
                newName: "transactionDate");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_BankAccountId",
                table: "Transaction",
                newName: "IX_Transaction_bankAccountid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BankAccount",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "BankAccount",
                newName: "expirationDate");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "BankAccount",
                newName: "cardNumber");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryName",
                table: "BankAccount",
                newName: "beneficiaryName");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "BankAccount",
                newName: "accountNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BankAccount",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccount_UserId",
                table: "BankAccount",
                newName: "IX_BankAccount_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AspNetUsers_userId",
                table: "BankAccount",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_bankAccountid",
                table: "Transaction",
                column: "bankAccountid",
                principalTable: "BankAccount",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_userId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_bankAccountid",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "BankAccount",
                newName: "BankAccount");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "dateOfBirth",
                table: "AspNetUsers",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "transactionType",
                table: "Transaction",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "toAccountId",
                table: "Transaction",
                newName: "ToAccountId");

            migrationBuilder.RenameColumn(
                name: "success",
                table: "Transaction",
                newName: "Success");

            migrationBuilder.RenameColumn(
                name: "fromAccountId",
                table: "Transaction",
                newName: "FromAccountId");

            migrationBuilder.RenameColumn(
                name: "bankAccountid",
                table: "Transaction",
                newName: "BankAccountId");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Transaction",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transaction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "transactionDate",
                table: "Transaction",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_bankAccountid",
                table: "Transaction",
                newName: "IX_Transaction_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "BankAccount",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "expirationDate",
                table: "BankAccount",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "cardNumber",
                table: "BankAccount",
                newName: "CardNumber");

            migrationBuilder.RenameColumn(
                name: "beneficiaryName",
                table: "BankAccount",
                newName: "BeneficiaryName");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "BankAccount",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BankAccount",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccount_userId",
                table: "BankAccount",
                newName: "IX_BankAccount_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AspNetUsers_UserId",
                table: "BankAccount",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
