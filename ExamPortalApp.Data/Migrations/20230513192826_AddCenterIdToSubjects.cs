using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCenterIdToSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CenterId",
                table: "Subjects",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Centers_CenterId",
                table: "Subjects",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Centers_CenterId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CenterId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Subjects");
        }
    }
}
