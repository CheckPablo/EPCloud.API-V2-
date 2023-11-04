using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentSubjects_link_to_students : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentSubjects");
        }
    }
}
