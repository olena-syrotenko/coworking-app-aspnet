using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoworkingApp.Migrations
{
    public partial class ShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Room");

            migrationBuilder.CreateTable(
                name: "RentCartItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    placeid = table.Column<int>(type: "int", nullable: true),
                    rentStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    rentEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    price = table.Column<double>(type: "double", nullable: false),
                    rentCartId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCartItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_RentCartItem_Place_placeid",
                        column: x => x.placeid,
                        principalTable: "Place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RentCartItem_placeid",
                table: "RentCartItem",
                column: "placeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentCartItem");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Room",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
