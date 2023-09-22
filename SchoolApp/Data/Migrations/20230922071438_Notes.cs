using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class Notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_StudentId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_Note_StudentId",
                table: "Notes",
                newName: "IX_Notes_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_StudentId",
                table: "Notes",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_StudentId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_StudentId",
                table: "Note",
                newName: "IX_Note_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_AspNetUsers_StudentId",
                table: "Note",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
