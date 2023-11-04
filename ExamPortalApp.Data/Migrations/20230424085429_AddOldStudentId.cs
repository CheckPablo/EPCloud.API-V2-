using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOldStudentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects");

            migrationBuilder.AddColumn<int>(
                name: "OldStudentId",
                table: "StudentSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId_SubjectId",
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId" },
                unique: true,
                filter: "[StudentId] IS NOT NULL AND [SubjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentId_SubjectId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "OldStudentId",
                table: "StudentSubjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK__aStudent__54F6B8C150939476",
                table: "StudentSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects",
                table: "StudentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
