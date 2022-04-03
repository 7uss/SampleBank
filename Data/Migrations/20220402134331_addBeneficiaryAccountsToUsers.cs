using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBank.Data.Migrations
{
    public partial class addBeneficiaryAccountsToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_userId",
                table: "BankAccount");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "BankAccount",
                type: "INTEGER",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserBeneficiaryAccounts",
                columns: table => new
                {
                    beneficiaryAccountsid = table.Column<int>(type: "INTEGER", nullable: false),
                    beneficiaryUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBeneficiaryAccounts", x => new { x.beneficiaryAccountsid, x.beneficiaryUsersId });
                    table.ForeignKey(
                        name: "FK_UserBeneficiaryAccounts_AspNetUsers_beneficiaryUsersId",
                        column: x => x.beneficiaryUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBeneficiaryAccounts_BankAccount_beneficiaryAccountsid",
                        column: x => x.beneficiaryAccountsid,
                        principalTable: "BankAccount",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBeneficiaryAccounts_beneficiaryUsersId",
                table: "UserBeneficiaryAccounts",
                column: "beneficiaryUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AspNetUsers_userId",
                table: "BankAccount",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_userId",
                table: "BankAccount");

            migrationBuilder.DropTable(
                name: "UserBeneficiaryAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "BankAccount",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AspNetUsers_userId",
                table: "BankAccount",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
