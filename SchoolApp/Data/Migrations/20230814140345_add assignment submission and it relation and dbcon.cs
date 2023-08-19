using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class addassignmentsubmissionanditrelationanddbcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_Assignments_AssignmentId",
                table: "AssignmentSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmission",
                newName: "AssignmentSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmission_AssignmentId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmissions",
                newName: "AssignmentSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId",
                table: "AssignmentSubmission",
                newName: "IX_AssignmentSubmission_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_Assignments_AssignmentId",
                table: "AssignmentSubmission",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
