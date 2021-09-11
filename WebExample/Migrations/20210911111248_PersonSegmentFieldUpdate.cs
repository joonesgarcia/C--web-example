using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExample.Migrations
{
    public partial class PersonSegmentFieldUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalSpend",
                table: "Segment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSpend",
                table: "Person",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSpend",
                table: "Segment");

            migrationBuilder.DropColumn(
                name: "TotalSpend",
                table: "Person");
        }
    }
}
