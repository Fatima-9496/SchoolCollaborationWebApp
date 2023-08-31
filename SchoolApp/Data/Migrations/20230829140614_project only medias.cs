using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class projectonlymedias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMediaUrl",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "VideoMediaUrl",
                table: "Projects",
                newName: "MediaUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaUrl",
                table: "Projects",
                newName: "VideoMediaUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageMediaUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
