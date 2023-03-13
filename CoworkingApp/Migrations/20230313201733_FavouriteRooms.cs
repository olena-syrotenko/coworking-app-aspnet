using Microsoft.EntityFrameworkCore.Migrations;

namespace CoworkingApp.Migrations
{
    public partial class FavouriteRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFavourite",
                table: "Room",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavourite",
                table: "Room");
        }
    }
}
