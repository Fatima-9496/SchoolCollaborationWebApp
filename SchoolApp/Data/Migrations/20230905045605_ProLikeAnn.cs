using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class ProLikeAnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentId",
                table: "Projects",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_StudentId",
                table: "Projects",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_StudentId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StudentId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Projects");
        }
    }
}
