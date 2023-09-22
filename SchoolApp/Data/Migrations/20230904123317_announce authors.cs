using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class announceauthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnnTearcherId",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnTearcherId",
                table: "Announcements",
                column: "AnnTearcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_AnnTearcherId",
                table: "Announcements",
                column: "AnnTearcherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_AnnTearcherId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_AnnTearcherId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AnnTearcherId",
                table: "Announcements");
        }
    }
}
