using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class userandannouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropColumn(
                name: "AppUserConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserPassword",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUsername",
                table: "AspNetUsers",
                newName: "LastNmae");

            migrationBuilder.AddColumn<string>(
                name: "FirstNmae",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementTitle",
                table: "Announcements",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementDescription",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstNmae",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastNmae",
                table: "AspNetUsers",
                newName: "AppUsername");

            migrationBuilder.AddColumn<string>(
                name: "AppUserConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementTitle",
                table: "Announcements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementDescription",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StudentId",
                table: "Notes",
                column: "StudentId");
        }
    }
}
