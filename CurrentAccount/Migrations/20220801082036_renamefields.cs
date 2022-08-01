using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrentAccount.Migrations
{
    public partial class renamefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "initialcredit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "initialcredit",
                table: "Accounts",
                newName: "Balance");
        }
    }
}
