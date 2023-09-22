using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class propssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnounceAndProjViews",
                columns: table => new
                {
                    AnprId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceAndProjViews", x => x.AnprId);
                    table.ForeignKey(
                        name: "FK_AnnounceAndProjViews_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "AnnouncementId");
                    table.ForeignKey(
                        name: "FK_AnnounceAndProjViews_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceAndProjViews_AnnouncementId",
                table: "AnnounceAndProjViews",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceAndProjViews_ProjectId",
                table: "AnnounceAndProjViews",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnounceAndProjViews");
        }
    }
}
