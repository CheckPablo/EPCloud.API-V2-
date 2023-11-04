using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviorSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Me__Appli__1387E197",
                table: "aspnet_Membership");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Me__UserI__1293BD5E",
                table: "aspnet_Membership");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Pa__Appli__1A34DF26",
                table: "aspnet_Paths");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Pe__PathI__1C1D2798",
                table: "aspnet_PersonalizationAllUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Pr__UserI__21D600EE",
                table: "aspnet_Profile");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Ro__Appli__23BE4960",
                table: "aspnet_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Us__Appli__25A691D2",
                table: "aspnet_Users");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Us__RoleI__278EDA44",
                table: "aspnet_UsersInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Us__UserI__2882FE7D",
                table: "aspnet_UsersInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusImages_Images",
                table: "StimulusImages");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusImages_Stimuli",
                table: "StimulusImages");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusMedia_Media",
                table: "StimulusMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusMedia_Stimuli",
                table: "StimulusMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_StimulusImages_Images",
                table: "StimulusImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusImages_Stimuli",
                table: "StimulusImages",
                column: "StimulusId",
                principalTable: "Stimuli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusMedia_Media",
                table: "StimulusMedia",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusMedia_Stimuli",
                table: "StimulusMedia",
                column: "StimulusId",
                principalTable: "Stimuli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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
                name: "FK_Answers_Questions",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Me__Appli__1387E197",
                table: "aspnet_Membership");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Me__UserI__1293BD5E",
                table: "aspnet_Membership");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Pa__Appli__1A34DF26",
                table: "aspnet_Paths");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Pe__PathI__1C1D2798",
                table: "aspnet_PersonalizationAllUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Pr__UserI__21D600EE",
                table: "aspnet_Profile");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Ro__Appli__23BE4960",
                table: "aspnet_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Us__Appli__25A691D2",
                table: "aspnet_Users");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Us__RoleI__278EDA44",
                table: "aspnet_UsersInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK__aspnet_Us__UserI__2882FE7D",
                table: "aspnet_UsersInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusImages_Images",
                table: "StimulusImages");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusImages_Stimuli",
                table: "StimulusImages");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusMedia_Media",
                table: "StimulusMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_StimulusMedia_Stimuli",
                table: "StimulusMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Me__Appli__1387E197",
                table: "aspnet_Membership",
                column: "ApplicationId",
                principalTable: "aspnet_Applications",
                principalColumn: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Me__UserI__1293BD5E",
                table: "aspnet_Membership",
                column: "UserId",
                principalTable: "aspnet_Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Pa__Appli__1A34DF26",
                table: "aspnet_Paths",
                column: "ApplicationId",
                principalTable: "aspnet_Applications",
                principalColumn: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Pe__PathI__1C1D2798",
                table: "aspnet_PersonalizationAllUsers",
                column: "PathId",
                principalTable: "aspnet_Paths",
                principalColumn: "PathId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Pr__UserI__21D600EE",
                table: "aspnet_Profile",
                column: "UserId",
                principalTable: "aspnet_Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Ro__Appli__23BE4960",
                table: "aspnet_Roles",
                column: "ApplicationId",
                principalTable: "aspnet_Applications",
                principalColumn: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Us__Appli__25A691D2",
                table: "aspnet_Users",
                column: "ApplicationId",
                principalTable: "aspnet_Applications",
                principalColumn: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Us__RoleI__278EDA44",
                table: "aspnet_UsersInRoles",
                column: "RoleId",
                principalTable: "aspnet_Roles",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK__aspnet_Us__UserI__2882FE7D",
                table: "aspnet_UsersInRoles",
                column: "UserId",
                principalTable: "aspnet_Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandomOTPs_Centers",
                table: "RandomOTPs",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stimuli_Sectors",
                table: "Stimuli",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusImages_Images",
                table: "StimulusImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusImages_Stimuli",
                table: "StimulusImages",
                column: "StimulusId",
                principalTable: "Stimuli",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusMedia_Media",
                table: "StimulusMedia",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StimulusMedia_Stimuli",
                table: "StimulusMedia",
                column: "StimulusId",
                principalTable: "Stimuli",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Questions",
                table: "TestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Tests",
                table: "TestQuestions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocumentAnswers_Students",
                table: "UserDocumentAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Centers",
                table: "Users",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");
        }
    }
}
