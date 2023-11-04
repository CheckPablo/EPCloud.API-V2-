using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProvinceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_lProvinces",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "UQ__lProvinc__FD0A6FA290063997",
                table: "Provinces");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Provinces",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Provinces");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Provinces",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lProvinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UQ__lProvinc__FD0A6FA290063997",
                table: "Provinces",
                column: "Id",
                unique: true);
        }
    }
}
