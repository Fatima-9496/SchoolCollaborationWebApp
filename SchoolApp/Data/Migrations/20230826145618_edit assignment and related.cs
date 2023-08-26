using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class editassignmentandrelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropColumn(
                name: "score",
                table: "AssignmentSubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "SubmissionFileUrl",
                table: "AssignmentSubmissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionDate",
                table: "AssignmentSubmissions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "AssignmentSubmissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "AssignmentSubmissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubmissionText",
                table: "AssignmentSubmissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmissions_StudentId",
                table: "AssignmentSubmissions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_StudentId",
                table: "AssignmentSubmissions",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_StudentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentSubmissions_StudentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "AssignmentSubmissions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropColumn(
                name: "SubmissionText",
                table: "AssignmentSubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "SubmissionFileUrl",
                table: "AssignmentSubmissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionDate",
                table: "AssignmentSubmissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AssignmentSubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "AssignmentSubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
