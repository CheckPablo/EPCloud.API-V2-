using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedStudentSectorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldStudentId",
                table: "StudentSubjects");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Students",
                newName: "GradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Students",
                newName: "SectorId");

            migrationBuilder.AddColumn<int>(
                name: "OldStudentId",
                table: "StudentSubjects",
                type: "int",
                nullable: true);
        }
    }
}
