using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class nameerror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastNmae",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FirstNmae",
                table: "AspNetUsers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "LastNmae");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "FirstNmae");
        }
    }
}
