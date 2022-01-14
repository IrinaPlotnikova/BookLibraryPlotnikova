using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangesTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_BookStatuses_BookStatusId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_BookCheckouts_BookCheckoutId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions");

            migrationBuilder.RenameColumn(
                name: "BookCheckoutId",
                table: "MoneyTransactions",
                newName: "ReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_MoneyTransactions_BookCheckoutId",
                table: "MoneyTransactions",
                newName: "IX_MoneyTransactions_ReaderId");

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "Readers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Readers",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LibraryCard",
                table: "Readers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Readers",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookCopyId",
                table: "MoneyTransactions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Books",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_BookCopyId",
                table: "MoneyTransactions",
                column: "BookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_BookStatuses_BookStatusId",
                table: "BookCopies",
                column: "BookStatusId",
                principalTable: "BookStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_BookStatuses_BookStatusId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_BookCopies_BookCopyId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_Readers_ReaderId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_BookCopyId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "BookCopyId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "MoneyTransactions",
                newName: "BookCheckoutId");

            migrationBuilder.RenameIndex(
                name: "IX_MoneyTransactions_ReaderId",
                table: "MoneyTransactions",
                newName: "IX_MoneyTransactions_BookCheckoutId");

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "Readers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Readers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LibraryCard",
                table: "Readers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Readers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_BookStatuses_BookStatusId",
                table: "BookCopies",
                column: "BookStatusId",
                principalTable: "BookStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_BookCheckouts_BookCheckoutId",
                table: "MoneyTransactions",
                column: "BookCheckoutId",
                principalTable: "BookCheckouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_MoneyTransactionTypes_MoneyTransactionTyp~",
                table: "MoneyTransactions",
                column: "MoneyTransactionTypeId",
                principalTable: "MoneyTransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
