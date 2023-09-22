using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class courseteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CTearcherId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CTearcherId",
                table: "Courses",
                column: "CTearcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CTearcherId",
                table: "Courses",
                column: "CTearcherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CTearcherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CTearcherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CTearcherId",
                table: "Courses");
        }
    }
}
