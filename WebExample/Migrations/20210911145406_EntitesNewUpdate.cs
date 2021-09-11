using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExample.Migrations
{
    public partial class EntitesNewUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendsRecord_Person_PersonId",
                table: "SpendsRecord");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "SpendsRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpendsRecord_Person_PersonId",
                table: "SpendsRecord",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendsRecord_Person_PersonId",
                table: "SpendsRecord");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "SpendsRecord",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SpendsRecord_Person_PersonId",
                table: "SpendsRecord",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
