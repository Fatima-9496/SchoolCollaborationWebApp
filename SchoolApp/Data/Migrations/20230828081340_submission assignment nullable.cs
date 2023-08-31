using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class submissionassignmentnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "AssignmentSubmissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "AssignmentSubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
