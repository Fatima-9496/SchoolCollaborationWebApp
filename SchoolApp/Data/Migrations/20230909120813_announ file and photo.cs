using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class announfileandphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnouncementFile",
                table: "Announcements");

            migrationBuilder.AddColumn<string>(
                name: "AnnouncementDocFile",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnnouncementPhoto",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnouncementDocFile",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AnnouncementPhoto",
                table: "Announcements");

            migrationBuilder.AddColumn<string>(
                name: "AnnouncementFile",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
