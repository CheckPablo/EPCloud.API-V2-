using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "UploadedSourceDocuments");

            migrationBuilder.DropColumn(
                name: "FileReference",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "DateModifed",
                table: "UploadedAnswerDocuments",
                newName: "DateModified");

            migrationBuilder.AddColumn<byte[]>(
                name: "TestDocument",
                table: "Tests",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDocument",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "UploadedAnswerDocuments",
                newName: "DateModifed");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "UploadedSourceDocuments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileReference",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
