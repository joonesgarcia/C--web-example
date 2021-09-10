using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExample.Migrations
{
    public partial class SpendsFieldUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SpendsRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SpendsRecord");
        }
    }
}
