using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    public partial class addtestsubmissionanditrelationtodgcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmission_Tests_TestId",
                table: "TestSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSubmission",
                table: "TestSubmission");

            migrationBuilder.RenameTable(
                name: "TestSubmission",
                newName: "TestSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_TestSubmission_TestId",
                table: "TestSubmissions",
                newName: "IX_TestSubmissions_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSubmissions",
                table: "TestSubmissions",
                column: "TestSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmissions_Tests_TestId",
                table: "TestSubmissions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmissions_Tests_TestId",
                table: "TestSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSubmissions",
                table: "TestSubmissions");

            migrationBuilder.RenameTable(
                name: "TestSubmissions",
                newName: "TestSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_TestSubmissions_TestId",
                table: "TestSubmission",
                newName: "IX_TestSubmission_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSubmission",
                table: "TestSubmission",
                column: "TestSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_Tests_TestId",
                table: "TestSubmission",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
