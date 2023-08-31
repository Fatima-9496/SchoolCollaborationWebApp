using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class submissionstudentnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_StudentId",
                table: "AssignmentSubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "AssignmentSubmissions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_StudentId",
                table: "AssignmentSubmissions",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_StudentId",
                table: "AssignmentSubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "AssignmentSubmissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_StudentId",
                table: "AssignmentSubmissions",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
