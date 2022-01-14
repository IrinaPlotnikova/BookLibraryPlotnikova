using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteLostBookFineFromBookCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LostBookFine",
                table: "BookCheckouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LostBookFine",
                table: "BookCheckouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
