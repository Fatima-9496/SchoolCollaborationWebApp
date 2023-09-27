using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class asssubucou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "AssignmentSubmissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "AssignmentSubmissions",
                type: "bit",
                nullable: true);
        }
    }
}
