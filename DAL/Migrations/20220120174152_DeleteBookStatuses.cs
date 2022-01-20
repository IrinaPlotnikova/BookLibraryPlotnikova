using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteBookStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_BookStatuses_BookStatusId",
                table: "BookCopies");

            migrationBuilder.DropTable(
                name: "BookStatuses");

            migrationBuilder.DropIndex(
                name: "IX_BookCopies_BookStatusId",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "BookStatusId",
                table: "BookCopies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookStatusId",
                table: "BookCopies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookStatusId",
                table: "BookCopies",
                column: "BookStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_BookStatuses_BookStatusId",
                table: "BookCopies",
                column: "BookStatusId",
                principalTable: "BookStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
