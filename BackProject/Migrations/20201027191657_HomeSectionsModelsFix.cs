using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class HomeSectionsModelsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_NoticeSections_NoticeSectionId",
                table: "Notices");

            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Notices_NoticesId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_NoticesId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "NoticeId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "NoticesId",
                table: "Notices");

            migrationBuilder.AlterColumn<int>(
                name: "NoticeSectionId",
                table: "Notices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_NoticeSections_NoticeSectionId",
                table: "Notices",
                column: "NoticeSectionId",
                principalTable: "NoticeSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_NoticeSections_NoticeSectionId",
                table: "Notices");

            migrationBuilder.AlterColumn<int>(
                name: "NoticeSectionId",
                table: "Notices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NoticeId",
                table: "Notices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoticesId",
                table: "Notices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notices_NoticesId",
                table: "Notices",
                column: "NoticesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_NoticeSections_NoticeSectionId",
                table: "Notices",
                column: "NoticeSectionId",
                principalTable: "NoticeSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Notices_NoticesId",
                table: "Notices",
                column: "NoticesId",
                principalTable: "Notices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
