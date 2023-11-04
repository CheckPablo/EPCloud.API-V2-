using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameCandidateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "StudentSubjects");

            migrationBuilder.CreateIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "StudentSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects",
                columns: new[] { "CandidateId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");
        }
    }
}
