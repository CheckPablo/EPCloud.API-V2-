using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Questions",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Tests",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocumentAnswers_Students",
                table: "UserDocumentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Centers",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserScannedImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDocumentAnswersBackups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDocumentAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UploadedTests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UploadedSourceDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UploadedAnswerDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TestTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TestSecurityLevels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TestQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TestCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentTests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentTestLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentSubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sectors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Screenshots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Regions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RandomOTPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Provinces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KeyPressTrackings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Irregularities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InvigilatorStudentLinks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DisclaimerAccepts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CenterTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Centers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Assessments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Questions",
                table: "TestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Tests",
                table: "TestQuestions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocumentAnswers_Students",
                table: "UserDocumentAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Centers",
                table: "Users",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Questions",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Tests",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocumentAnswers_Students",
                table: "UserDocumentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Centers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserScannedImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDocumentAnswersBackups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDocumentAnswers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UploadedTests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UploadedSourceDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UploadedAnswerDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TestTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TestSecurityLevels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TestCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentTests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentTestLogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RandomOTPs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KeyPressTrackings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Irregularities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InvigilatorStudentLinks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DisclaimerAccepts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CenterTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Assessments");

            migrationBuilder.AddForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Questions",
                table: "TestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Tests",
                table: "TestQuestions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocumentAnswers_Students",
                table: "UserDocumentAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Centers",
                table: "Users",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
