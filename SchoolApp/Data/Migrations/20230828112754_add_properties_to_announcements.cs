using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class add_properties_to_announcements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Announcements");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Announcements",
                newName: "PostDate");

            migrationBuilder.AddColumn<string>(
                name: "AnnouncementAuthor",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnouncementAuthor",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Announcements");

            migrationBuilder.RenameColumn(
                name: "PostDate",
                table: "Announcements",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Announcements",
                type: "datetime2",
                nullable: true);
        }
    }
}
