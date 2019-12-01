using Microsoft.EntityFrameworkCore.Migrations;

namespace AsteroidDodge.Migrations
{
    public partial class CurrentShipAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentBackgrounId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentShipId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBackgrounId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentShipId",
                table: "AspNetUsers");
        }
    }
}
