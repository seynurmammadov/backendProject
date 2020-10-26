using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class fixTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseModerators_Events_EventId",
                table: "CourseModerators");

            migrationBuilder.DropIndex(
                name: "IX_CourseModerators_EventId",
                table: "CourseModerators");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "CourseModerators");

            migrationBuilder.AddColumn<bool>(
                name: "Activeted",
                table: "Tags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activeted",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "CourseModerators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseModerators_EventId",
                table: "CourseModerators",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseModerators_Events_EventId",
                table: "CourseModerators",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
