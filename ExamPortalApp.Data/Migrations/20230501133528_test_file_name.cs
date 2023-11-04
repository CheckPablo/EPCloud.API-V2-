using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class test_file_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileReference",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "FileReference",
                table: "Tests");
        }
    }
}
