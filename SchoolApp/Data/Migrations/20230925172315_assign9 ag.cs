using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class assign9ag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentMaterial",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CourseIds",
                table: "Assignments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentTitle",
                table: "Assignments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Assignments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentTitle",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "AssignmentMaterial",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseIds",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
