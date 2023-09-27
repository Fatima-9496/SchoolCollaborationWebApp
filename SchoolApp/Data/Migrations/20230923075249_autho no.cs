using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class authono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnouncementAuthor",
                table: "Announcements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnnouncementAuthor",
                table: "Announcements",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
