using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class HomeSectionsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 420, nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestimonialSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    Surname = table.Column<string>(maxLength: 20, nullable: false),
                    Position = table.Column<string>(maxLength: 40, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 600, nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeTime = table.Column<DateTime>(nullable: false),
                    NoticeText = table.Column<string>(maxLength: 420, nullable: false),
                    NoticeId = table.Column<int>(nullable: false),
                    NoticesId = table.Column<int>(nullable: true),
                    NoticeSectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notices_NoticeSections_NoticeSectionId",
                        column: x => x.NoticeSectionId,
                        principalTable: "NoticeSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notices_Notices_NoticesId",
                        column: x => x.NoticesId,
                        principalTable: "Notices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_NoticeSectionId",
                table: "Notices",
                column: "NoticeSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_NoticesId",
                table: "Notices",
                column: "NoticesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSections");

            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "TestimonialSections");

            migrationBuilder.DropTable(
                name: "NoticeSections");
        }
    }
}
