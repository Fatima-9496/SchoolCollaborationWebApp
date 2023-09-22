using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmissionFileUrl",
                table: "AssignmentSubmissions",
                newName: "AnnouncementDocFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnnouncementDocFile",
                table: "AssignmentSubmissions",
                newName: "SubmissionFileUrl");
        }
    }
}
