﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class asssubu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseMaterial",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseMaterial",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
