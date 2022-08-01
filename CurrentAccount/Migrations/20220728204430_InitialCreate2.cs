using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrentAccount.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AccountTransactions_AccountTransactionId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "AccountTransactions");

            migrationBuilder.DropTable(
                name: "CustomersInfo");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountTransactionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountTransactionId",
                table: "Transactions");

            migrationBuilder.AlterColumn<double>(
                name: "balance",
                table: "Accounts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTransactionId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "balance",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "CustomersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CustomerInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_CustomersInfo_CustomerInfoId",
                        column: x => x.CustomerInfoId,
                        principalTable: "CustomersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountTransactionId",
                table: "Transactions",
                column: "AccountTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_CustomerInfoId",
                table: "AccountTransactions",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AccountTransactions_AccountTransactionId",
                table: "Transactions",
                column: "AccountTransactionId",
                principalTable: "AccountTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
