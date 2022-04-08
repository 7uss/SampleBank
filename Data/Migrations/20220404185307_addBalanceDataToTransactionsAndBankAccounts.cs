using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBank.Data.Migrations
{
    public partial class addBalanceDataToTransactionsAndBankAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "Transaction",
                type: "DECIMAL(10,4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<decimal>(
                name: "newBalance",
                table: "Transaction",
                type: "DECIMAL(10,4)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "oldBalance",
                table: "Transaction",
                type: "DECIMAL(10,4)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "BankAccount",
                type: "DECIMAL(10,4)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newBalance",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "oldBalance",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "BankAccount");

            migrationBuilder.AlterColumn<float>(
                name: "amount",
                table: "Transaction",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,4)");
        }
    }
}
