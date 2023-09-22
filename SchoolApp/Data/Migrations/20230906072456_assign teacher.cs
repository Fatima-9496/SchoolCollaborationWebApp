using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class assignteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ATearcherId",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AppUserId",
                table: "Assignments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_AppUserId",
                table: "Assignments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_AppUserId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AppUserId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ATearcherId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Assignments");
        }
    }
}
