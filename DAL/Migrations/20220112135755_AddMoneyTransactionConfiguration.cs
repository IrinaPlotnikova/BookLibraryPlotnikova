using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMoneyTransactionConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_BookCopies_BookCopyId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_Readers_ReaderId",
                table: "MoneyTransactions");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_BookCopies_BookCopyId",
                table: "MoneyTransactions",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions",
                column: "MoneyTransactionTypeId",
                principalTable: "MoneyTransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_Readers_ReaderId",
                table: "MoneyTransactions",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_BookCopies_BookCopyId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_Readers_ReaderId",
                table: "MoneyTransactions");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_BookCopies_BookCopyId",
                table: "MoneyTransactions",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions",
                column: "MoneyTransactionTypeId",
                principalTable: "MoneyTransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_Readers_ReaderId",
                table: "MoneyTransactions",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
