using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class FixTeacherDes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescribtion",
                table: "TeacherDescriptions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TeacherDescriptions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TeacherDescriptions");

            migrationBuilder.AddColumn<string>(
                name: "FullDescribtion",
                table: "TeacherDescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
