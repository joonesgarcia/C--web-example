using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExample.Migrations
{
    public partial class SegmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendsRecord_Segment_SegmentId",
                table: "SpendsRecord");

            migrationBuilder.AlterColumn<int>(
                name: "SegmentId",
                table: "SpendsRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpendsRecord_Segment_SegmentId",
                table: "SpendsRecord",
                column: "SegmentId",
                principalTable: "Segment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendsRecord_Segment_SegmentId",
                table: "SpendsRecord");

            migrationBuilder.AlterColumn<int>(
                name: "SegmentId",
                table: "SpendsRecord",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SpendsRecord_Segment_SegmentId",
                table: "SpendsRecord",
                column: "SegmentId",
                principalTable: "Segment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
