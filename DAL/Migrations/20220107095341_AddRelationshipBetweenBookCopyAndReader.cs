using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddRelationshipBetweenBookCopyAndReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReaderId",
                table: "BookCopies",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBookReturned",
                table: "BookCheckouts",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_ReaderId",
                table: "BookCopies",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Readers_ReaderId",
                table: "BookCopies",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Readers_ReaderId",
                table: "BookCopies");

            migrationBuilder.DropIndex(
                name: "IX_BookCopies_ReaderId",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "ReaderId",
                table: "BookCopies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBookReturned",
                table: "BookCheckouts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
