using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class FixSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber1 = table.Column<string>(maxLength: 12, nullable: false),
                    PhoneNumber2 = table.Column<string>(maxLength: 12, nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 170, nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 70, nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: false),
                    SiteUrl = table.Column<string>(nullable: true),
                    LocationLaLatitude = table.Column<double>(nullable: false),
                    LocationLongitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteInfo");
        }
    }
}
