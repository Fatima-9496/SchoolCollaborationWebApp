using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class asssubureqmigrate1remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "AssignmentSubmissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "AssignmentSubmissions",
                type: "datetime2",
                nullable: true);
        }
    }
}
