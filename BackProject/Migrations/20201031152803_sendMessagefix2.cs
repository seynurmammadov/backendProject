using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class sendMessagefix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeletet",
                table: "SendMessageFromUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SendMessageFromUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SendMessageFromUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeletet",
                table: "SendMessageFromUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
