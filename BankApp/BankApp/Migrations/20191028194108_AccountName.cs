using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Migrations
{
    public partial class AccountName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "accountName",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountName",
                table: "Accounts");
        }
    }
}
