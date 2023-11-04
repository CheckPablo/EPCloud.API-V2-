using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFaultyConfigOnCreateCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_CenterTypes",
                table: "Centers");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Provinces",
                table: "Centers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Centers",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_CenterTypes",
                table: "Centers",
                column: "CenterTypeId",
                principalTable: "CenterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Provinces",
                table: "Centers",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_CenterTypes",
                table: "Centers");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Provinces",
                table: "Centers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Centers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_CenterTypes",
                table: "Centers",
                column: "CenterTypeId",
                principalTable: "CenterTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Provinces",
                table: "Centers",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");
        }
    }
}
