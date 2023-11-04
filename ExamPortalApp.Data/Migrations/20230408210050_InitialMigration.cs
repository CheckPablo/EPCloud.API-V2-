using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPortalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerMultiples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeId = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerMultiples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerProgressTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerCount = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerProgressTrackings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aspnet_Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ApplicationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LoweredApplicationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_A__C93A4C98CED8A85C", x => x.ApplicationId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "aspnet_SchemaVersions",
                columns: table => new
                {
                    Feature = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CompatibleSchemaVersion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsCurrentVersion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_S__5A1E6BC1BD356993", x => new { x.Feature, x.CompatibleSchemaVersion });
                });

            migrationBuilder.CreateTable(
                name: "bckaStimulusText",
                columns: table => new
                {
                    StimulusTextID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StimulusID = table.Column<int>(type: "int", nullable: true),
                    StimulusText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "bcktQuestion",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    QuestionTypeID = table.Column<int>(type: "int", nullable: true),
                    StimulusID = table.Column<int>(type: "int", nullable: true),
                    QuestionCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    QuestionStem = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    QuestionInstruction = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    NoteID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "buffer_aTestQuestion",
                columns: table => new
                {
                    TestQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    QuestionNo = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "buffer_tQuestion",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: true),
                    QuestionTypeID = table.Column<int>(type: "int", nullable: true),
                    StimulusID = table.Column<int>(type: "int", nullable: true),
                    QuestionCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    QuestionStem = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    QuestionInstruction = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    NoteID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CenterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CenterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CenterTypes1",
                columns: table => new
                {
                    CenterTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lCenterT__790E764CE79327AC", x => x.CenterTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhysicalFile = table.Column<byte[]>(type: "image", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lLanguag__B938558B8A2A6A32", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhysicalFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Reference = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tNote__EACE357F11F1BBF1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberOfCandidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NumberOf__3214EC279D35C5E6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lProvinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lRating__FCCDF85CDE2A2ED2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Region__ACD844430335FEC3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SebSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HashDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SEBSettings = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    MacSEBSettings = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SEBsetti__174A327D1D94BAF0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StimulusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lStimulu__0C07AF7C36E62C1B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeRemaining = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HasMulti = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tStudent__C7ABDEA89BCCDEA2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentProgressTestUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: true),
                    TimeRemaining = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    ElectronicReader = table.Column<bool>(type: "bit", nullable: true),
                    Accomodation = table.Column<bool>(type: "bit", nullable: true),
                    StudentExtraTime = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tStudent__C7ABDEA8CAF79D33", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lSubject", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lTarget__2B1F0FB64734E311", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lTestCat__2CE3751DC4238E9D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestSecurityLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TestSecu__4064EDEA36A11696", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lTestTyp__9BB87646E25BCB6F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tmpBCKasns",
                columns: table => new
                {
                    StudentProgressID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    TestQuestionID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeRemaining = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    HasMulti = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UploadedAnswerDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    TestDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateModifed = table.Column<DateTime>(type: "datetime", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tUploade__A693271ADC4F3997", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    TestDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUploadedTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aspnet_Paths",
                columns: table => new
                {
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LoweredPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_P__CD67DC58395E0EF9", x => x.PathId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK__aspnet_Pa__Appli__1A34DF26",
                        column: x => x.ApplicationId,
                        principalTable: "aspnet_Applications",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LoweredRoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_R__8AFACE1BE0E47F96", x => x.RoleId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK__aspnet_Ro__Appli__23BE4960",
                        column: x => x.ApplicationId,
                        principalTable: "aspnet_Applications",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LoweredUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MobileAlias = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    LastActivityDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_U__1788CC4DDBEBEFD3", x => x.UserId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK__aspnet_Us__Appli__25A691D2",
                        column: x => x.ApplicationId,
                        principalTable: "aspnet_Applications",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    Prefix = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Disclaimer = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CenterNo = table.Column<int>(type: "int", nullable: true),
                    AttendanceRegisterPassword = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    MaximumLicense = table.Column<int>(type: "int", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CenterTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centers_CenterTypes",
                        column: x => x.CenterTypeId,
                        principalTable: "CenterTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Centers_Provinces",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    OldSubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aStudent__54F6B8C150939476", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_PersonalizationAllUsers",
                columns: table => new
                {
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageSettings = table.Column<byte[]>(type: "image", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_P__CD67DC59EDC10811", x => x.PathId);
                    table.ForeignKey(
                        name: "FK__aspnet_Pe__PathI__1C1D2798",
                        column: x => x.PathId,
                        principalTable: "aspnet_Paths",
                        principalColumn: "PathId");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_Membership",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordFormat = table.Column<int>(type: "int", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MobilePIN = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LoweredEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordQuestion = table.Column<int>(type: "int", nullable: true),
                    PasswordAnswer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastPasswordChangedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastLockoutDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FailedPasswordAttemptCount = table.Column<int>(type: "int", nullable: false),
                    FailedPasswordAttemptWindowStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    FailedPasswordAnswerAttemptCount = table.Column<int>(type: "int", nullable: false),
                    FailedPasswordAnswerAttemptWindowStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_M__1788CC4DCD837534", x => x.UserId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK__aspnet_Me__Appli__1387E197",
                        column: x => x.ApplicationId,
                        principalTable: "aspnet_Applications",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK__aspnet_Me__UserI__1293BD5E",
                        column: x => x.UserId,
                        principalTable: "aspnet_Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_PersonalizationPerUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PageSettings = table.Column<byte[]>(type: "image", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_P__3214EC06F3D7E7E5", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK__aspnet_Pe__PathI__1E05700A",
                        column: x => x.PathId,
                        principalTable: "aspnet_Paths",
                        principalColumn: "PathId");
                    table.ForeignKey(
                        name: "FK__aspnet_Pe__UserI__1EF99443",
                        column: x => x.UserId,
                        principalTable: "aspnet_Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_Profile",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyNames = table.Column<string>(type: "ntext", nullable: false),
                    PropertyValuesString = table.Column<string>(type: "ntext", nullable: false),
                    PropertyValuesBinary = table.Column<byte[]>(type: "image", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_P__1788CC4CAF9D5AE4", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__aspnet_Pr__UserI__21D600EE",
                        column: x => x.UserId,
                        principalTable: "aspnet_Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "aspnet_UsersInRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_U__AF2760AD5F7251C8", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK__aspnet_Us__RoleI__278EDA44",
                        column: x => x.RoleId,
                        principalTable: "aspnet_Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK__aspnet_Us__UserI__2882FE7D",
                        column: x => x.UserId,
                        principalTable: "aspnet_Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectors_Centers",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Surname = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Password = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    UserEmailAddress = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ContactDetails = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    NumberOfCandidates = table.Column<int>(type: "int", nullable: true),
                    VsoftApproved = table.Column<bool>(type: "bit", nullable: true),
                    TermsAndConditions = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    IsSchoolAdmin = table.Column<bool>(type: "bit", nullable: true),
                    CenterTypeId = table.Column<int>(type: "int", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CenterTypes",
                        column: x => x.CenterTypeId,
                        principalTable: "CenterTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Centers",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stimuli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HasImage = table.Column<bool>(type: "bit", nullable: true),
                    StimulusInstruction = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    StimulusTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stimuli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stimuli_Sectors",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stimuli_StimulusTypes",
                        column: x => x.StimulusTypeId,
                        principalTable: "StimulusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ExamNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    Updated = table.Column<bool>(type: "bit", nullable: true),
                    IsOnline = table.Column<bool>(type: "bit", nullable: true),
                    PasswordEncrypted = table.Column<byte[]>(type: "binary(64)", fixedLength: true, maxLength: 64, nullable: true),
                    Salt = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentNo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SentConfirmation = table.Column<bool>(type: "bit", nullable: true),
                    CertLangId = table.Column<int>(type: "int", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    OldRegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Centers",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Languages",
                        column: x => x.CertLangId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Regions",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Sectors",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    TestName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TestIntro = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TestDuration = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TestCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Tts = table.Column<bool>(type: "bit", nullable: true),
                    WorkOffline = table.Column<bool>(type: "bit", nullable: true),
                    TestSecurityLevelId = table.Column<int>(type: "int", nullable: true),
                    AnswerScanningAvailable = table.Column<bool>(type: "bit", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    TestTypeId = table.Column<int>(type: "int", nullable: true),
                    TestCategoryId = table.Column<int>(type: "int", nullable: true),
                    AlternateTestId = table.Column<int>(type: "int", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true),
                    OldSubjectId = table.Column<int>(type: "int", nullable: true),
                    OldSectorId = table.Column<int>(type: "int", nullable: true),
                    OldCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Centers",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Languages",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Sectors",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_TestCategories",
                        column: x => x.TestCategoryId,
                        principalTable: "TestCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_TestSecurityLevels",
                        column: x => x.TestSecurityLevelId,
                        principalTable: "TestSecurityLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_TestTypes",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<short>(type: "smallint", nullable: false),
                    OldUserId = table.Column<int>(type: "int", nullable: true),
                    OldCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Centers",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    QuestionStem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    NoteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: true),
                    StimulusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Stimuli",
                        column: x => x.StimulusId,
                        principalTable: "Stimuli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StimulusImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    StimulusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aStimulusImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StimulusImages_Images",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StimulusImages_Stimuli",
                        column: x => x.StimulusId,
                        principalTable: "Stimuli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StimulusMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    StimulusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StimulusMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StimulusMedia_Media",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StimulusMedia_Stimuli",
                        column: x => x.StimulusId,
                        principalTable: "Stimuli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StimulusTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StimulusText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    StimulusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StimulusTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StimulusTexts_Stimuli",
                        column: x => x.StimulusId,
                        principalTable: "Stimuli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BulkImportPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Surname = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    IdNumber = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    StudentNo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Imported = table.Column<bool>(type: "bit", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BulkImportPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulkImportPeople_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvigilatorStudentLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateModifed = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvigilatorId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvigilatorStudentLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvigilatorStudentLinks_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentRetrieves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncryptedText = table.Column<byte[]>(type: "varbinary(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentP__87F839308898F770", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentRetrieves_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisclaimerAccepts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accepted = table.Column<bool>(type: "bit", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DisclaimerAccepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisclaimerAccepts_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisclaimerAccepts_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Irregularities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyPress = table.Column<bool>(type: "bit", nullable: true),
                    LeftExamArea = table.Column<bool>(type: "bit", nullable: true),
                    Offline = table.Column<bool>(type: "bit", nullable: true),
                    FullScreenClosed = table.Column<bool>(type: "bit", nullable: true),
                    DateModifed = table.Column<DateTime>(type: "datetime", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Irregula__269B16718B26737B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Irregularities_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Irregularities_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KeyPressTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Reason = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyPressTrackings_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeyPressTrackings_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RandomOTPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OTP = table.Column<int>(type: "int", nullable: false),
                    OTPExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true),
                    OldSectorId = table.Column<int>(type: "int", nullable: true),
                    OldSubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomOTP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RandomOTPs_Centers",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RandomOTPs_Sectors",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RandomOTPs_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RandomOTPs_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Screenshots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenshotData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Screensh__DFD702D8B6DF1F20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenshots_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Screenshots_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTestLogs_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentTestLogs_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Absent = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ElectronicReader = table.Column<bool>(type: "bit", nullable: true),
                    Accomodation = table.Column<bool>(type: "bit", nullable: true),
                    StudentExtraTime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LoginUid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TestLoadedInBrowser = table.Column<bool>(type: "bit", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTests_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentTests_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UploadedSourceDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TestDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tUploade__1ABEEF6FCC72D0BF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedSourceDocuments_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDocumentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: true),
                    TestDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbUserDo__40A359E395DBA442", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocumentAnswers_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDocumentAnswers_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDocumentAnswersBackups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: true),
                    TestDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocumentAnswersBackups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocumentAnswersBackups_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDocumentAnswersBackups_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserScannedImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Complete = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    OldStudentId = table.Column<int>(type: "int", nullable: true),
                    OldTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserScannedImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScannedImages_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserScannedImages_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AnswerDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNo = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Questions",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BulkImportSectorSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorCode = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Sector = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    SubjectCode = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Subject = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    StudentNo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Imported = table.Column<bool>(type: "bit", nullable: true),
                    BulkImportId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    StudentSubjectId = table.Column<int>(type: "int", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BulkImportSectorSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulkImportSectorSubjects_Sectors",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BulkImportSectorSubjects_StudentSubjects",
                        column: x => x.StudentSubjectId,
                        principalTable: "StudentSubjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BulkImportSectorSubjects_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__BulkImpor__BulkI__0C90CB45",
                        column: x => x.BulkImportId,
                        principalTable: "BulkImportPeople",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    BitAbsent = table.Column<bool>(type: "bit", nullable: true),
                    BitLangChanged = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    TestQuestionId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assessments_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assessments_TestQuestions",
                        column: x => x.TestQuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assessments_Tests",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerProgressTrackings_TestId_StudentId",
                table: "AnswerProgressTrackings",
                columns: new[] { "TestId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerId",
                table: "Answers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerId_QuestionId",
                table: "Answers",
                columns: new[] { "AnswerId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId_AnswerId_AnswerDesc_OptionCode",
                table: "Answers",
                columns: new[] { "QuestionId", "AnswerId", "AnswerDesc", "OptionCode" });

            migrationBuilder.CreateIndex(
                name: "aspnet_Applications_Index",
                table: "aspnet_Applications",
                column: "LoweredApplicationName")
                .Annotation("SqlServer:Clustered", true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "UQ__aspnet_A__17477DE43F4045CA",
                table: "aspnet_Applications",
                column: "LoweredApplicationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__aspnet_A__3091033139F4CAB8",
                table: "aspnet_Applications",
                column: "ApplicationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnet_Membership_ApplicationId",
                table: "aspnet_Membership",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "aspnet_Paths_index",
                table: "aspnet_Paths",
                columns: new[] { "ApplicationId", "LoweredPath" },
                unique: true)
                .Annotation("SqlServer:Clustered", true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "aspnet_PersonalizationPerUser_index1",
                table: "aspnet_PersonalizationPerUser",
                columns: new[] { "PathId", "UserId" },
                unique: true)
                .Annotation("SqlServer:Clustered", true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "aspnet_PersonalizationPerUser_ncindex2",
                table: "aspnet_PersonalizationPerUser",
                columns: new[] { "UserId", "PathId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [PathId] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "aspnet_Roles_index1",
                table: "aspnet_Roles",
                columns: new[] { "ApplicationId", "LoweredRoleName" },
                unique: true)
                .Annotation("SqlServer:Clustered", true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "aspnet_Users_Index",
                table: "aspnet_Users",
                columns: new[] { "ApplicationId", "LoweredUserName" },
                unique: true)
                .Annotation("SqlServer:Clustered", true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "aspnet_Users_Index2",
                table: "aspnet_Users",
                columns: new[] { "ApplicationId", "LastActivityDate" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "aspnet_UsersInRoles_index",
                table: "aspnet_UsersInRoles",
                column: "RoleId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_StudentId",
                table: "Assessments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_SubjectId",
                table: "Assessments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_TestId",
                table: "Assessments",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_TestQuestionId",
                table: "Assessments",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BulkImportPeople_StudentId",
                table: "BulkImportPeople",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BulkImportSectorSubjects_BulkImportId",
                table: "BulkImportSectorSubjects",
                column: "BulkImportId");

            migrationBuilder.CreateIndex(
                name: "IX_BulkImportSectorSubjects_SectorId",
                table: "BulkImportSectorSubjects",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_BulkImportSectorSubjects_StudentSubjectId",
                table: "BulkImportSectorSubjects",
                column: "StudentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BulkImportSectorSubjects_SubjectId",
                table: "BulkImportSectorSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_CenterTypeId",
                table: "Centers",
                column: "CenterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_ProvinceId",
                table: "Centers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_DisclaimerAccepts_StudentId",
                table: "DisclaimerAccepts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestId_StudentId",
                table: "DisclaimerAccepts",
                columns: new[] { "TestId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_InvigilatorId_StudentId",
                table: "InvigilatorStudentLinks",
                columns: new[] { "InvigilatorId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_InvigilatorStudentLinks_StudentId",
                table: "InvigilatorStudentLinks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IDXTest_StudentID",
                table: "Irregularities",
                columns: new[] { "TestId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Irregularities_StudentId",
                table: "Irregularities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPressTrackings_TestId",
                table: "KeyPressTrackings",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentId_TestId",
                table: "KeyPressTrackings",
                columns: new[] { "StudentId", "TestId" });

            migrationBuilder.CreateIndex(
                name: "MediaID",
                table: "Media",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Removed",
                table: "Media",
                column: "Removed")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "UQ__lProvinc__FD0A6FA290063997",
                table: "Provinces",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Id_StimulusId",
                table: "Questions",
                columns: new[] { "Id", "StimulusId" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StimulusId",
                table: "Questions",
                column: "StimulusId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomOTPs",
                table: "RandomOTPs",
                columns: new[] { "CenterId", "SectorId", "SubjectId", "TestId" });

            migrationBuilder.CreateIndex(
                name: "IX_RandomOTPs_SectorId",
                table: "RandomOTPs",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomOTPs_SubjectId",
                table: "RandomOTPs",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomOTPs_TestId",
                table: "RandomOTPs",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-OTP",
                table: "RandomOTPs",
                column: "OTP");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_StudentId",
                table: "Screenshots",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_TestId",
                table: "Screenshots",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_CenterId",
                table: "Sectors",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "HasImage",
                table: "Stimuli",
                column: "HasImage")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Removed",
                table: "Stimuli",
                column: "Removed")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "SectionID",
                table: "Stimuli",
                column: "SectionId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "SectorID",
                table: "Stimuli",
                column: "SectorId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "StimulusID",
                table: "Stimuli",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "StimulusTypeID",
                table: "Stimuli",
                column: "StimulusTypeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "ImageID",
                table: "StimulusImages",
                column: "ImageId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_StimulusImages",
                table: "StimulusImages",
                columns: new[] { "ImageId", "StimulusId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Removed",
                table: "StimulusImages",
                column: "Removed")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "StimulusID",
                table: "StimulusImages",
                column: "StimulusId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "UQ__aStimulu__1619A5C21C2B9801",
                table: "StimulusImages",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StimulusMedia",
                table: "StimulusMedia",
                columns: new[] { "MediaId", "StimulusId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StimulusMedia_StimulusId",
                table: "StimulusMedia",
                column: "StimulusId");

            migrationBuilder.CreateIndex(
                name: "IX_StimulusText",
                table: "StimulusTexts",
                column: "StimulusId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "_dta_index_tStudentProgress_18_1563152614__K3_K2",
                table: "StudentProgress",
                columns: new[] { "TestId", "StudentId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "_dta_index_tStudentProgress_18_1563152614__K3_K2_K4_K7_K1",
                table: "StudentProgress",
                columns: new[] { "TestId", "StudentId", "QuestionId", "AnswerId", "Id" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress",
                table: "StudentProgress",
                columns: new[] { "StudentId", "TestId", "QuestionId", "AnswerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDXStudent_TestID",
                table: "StudentProgressTestUploads",
                columns: new[] { "StudentId", "TestId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgressTestUploads",
                table: "StudentProgressTestUploads",
                columns: new[] { "TestId", "StudentId" },
                unique: true,
                filter: "[TestId] IS NOT NULL AND [StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IDXStudentID",
                table: "StudentRetrieves",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "_dta_index_tStudent_18_1778105375__K1_4",
                table: "Students",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "CenterID",
                table: "Students",
                column: "CenterId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IDXName",
                table: "Students",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IDXSector",
                table: "Students",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CertLangId",
                table: "Students",
                column: "CertLangId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RegionId",
                table: "Students",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "Remove",
                table: "Students",
                column: "Removed")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "StudentID",
                table: "Students",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Update",
                table: "Students",
                column: "Updated")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IDXCandidate_SubjectID",
                table: "StudentSubjects",
                columns: new[] { "CandidateId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestLogs_StudentId",
                table: "StudentTestLogs",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestLogs_TestId",
                table: "StudentTestLogs",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTests",
                table: "StudentTests",
                columns: new[] { "StudentId", "TestId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTests_TestId",
                table: "StudentTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "PKSubjectID",
                table: "Subjects",
                column: "Id",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions",
                table: "TestQuestions",
                columns: new[] { "TestId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_QuestionId",
                table: "TestQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "_dta_index_tTest_18_151671588__K1",
                table: "Tests",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CenterId",
                table: "Tests",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LanguageId",
                table: "Tests",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SectorId",
                table: "Tests",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestCategoryId",
                table: "Tests",
                column: "TestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestSecurityLevelId",
                table: "Tests",
                column: "TestSecurityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestTypeId",
                table: "Tests",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20200723-181115",
                table: "Tests",
                columns: new[] { "Id", "SubjectId", "ExamId", "CenterId" });

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20210726-134543",
                table: "Tests",
                column: "PaperExpiryDate");

            migrationBuilder.CreateIndex(
                name: "IX_tUploadedAnswerDocument",
                table: "UploadedAnswerDocuments",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IDXTestID",
                table: "UploadedSourceDocuments",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IDXStudent_TestID",
                table: "UserDocumentAnswers",
                columns: new[] { "TestId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDocumentAnswers_StudentId",
                table: "UserDocumentAnswers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocumentAnswersBackups_StudentId",
                table: "UserDocumentAnswersBackups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocumentAnswersBackups_TestId",
                table: "UserDocumentAnswersBackups",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CenterId",
                table: "UserRoles",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CenterId",
                table: "Users",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CenterTypeId",
                table: "Users",
                column: "CenterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Test",
                table: "UserScannedImages",
                columns: new[] { "StudentId", "TestId", "OTP" });

            migrationBuilder.CreateIndex(
                name: "IX_UserScannedImages_TestId",
                table: "UserScannedImages",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerMultiples");

            migrationBuilder.DropTable(
                name: "AnswerProgressTrackings");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AnswerTexts");

            migrationBuilder.DropTable(
                name: "aspnet_Membership");

            migrationBuilder.DropTable(
                name: "aspnet_PersonalizationAllUsers");

            migrationBuilder.DropTable(
                name: "aspnet_PersonalizationPerUser");

            migrationBuilder.DropTable(
                name: "aspnet_Profile");

            migrationBuilder.DropTable(
                name: "aspnet_SchemaVersions");

            migrationBuilder.DropTable(
                name: "aspnet_UsersInRoles");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "bckaStimulusText");

            migrationBuilder.DropTable(
                name: "bcktQuestion");

            migrationBuilder.DropTable(
                name: "buffer_aTestQuestion");

            migrationBuilder.DropTable(
                name: "buffer_tQuestion");

            migrationBuilder.DropTable(
                name: "BulkImportSectorSubjects");

            migrationBuilder.DropTable(
                name: "CenterTypes1");

            migrationBuilder.DropTable(
                name: "DisclaimerAccepts");

            migrationBuilder.DropTable(
                name: "InvigilatorStudentLinks");

            migrationBuilder.DropTable(
                name: "Irregularities");

            migrationBuilder.DropTable(
                name: "KeyPressTrackings");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NumberOfCandidates");

            migrationBuilder.DropTable(
                name: "RandomOTPs");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Screenshots");

            migrationBuilder.DropTable(
                name: "SebSettings");

            migrationBuilder.DropTable(
                name: "StimulusImages");

            migrationBuilder.DropTable(
                name: "StimulusMedia");

            migrationBuilder.DropTable(
                name: "StimulusTexts");

            migrationBuilder.DropTable(
                name: "StudentProgress");

            migrationBuilder.DropTable(
                name: "StudentProgressTestUploads");

            migrationBuilder.DropTable(
                name: "StudentRetrieves");

            migrationBuilder.DropTable(
                name: "StudentTestLogs");

            migrationBuilder.DropTable(
                name: "StudentTests");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "tmpBCKasns");

            migrationBuilder.DropTable(
                name: "UploadedAnswerDocuments");

            migrationBuilder.DropTable(
                name: "UploadedSourceDocuments");

            migrationBuilder.DropTable(
                name: "UploadedTests");

            migrationBuilder.DropTable(
                name: "UserDocumentAnswers");

            migrationBuilder.DropTable(
                name: "UserDocumentAnswersBackups");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserScannedImages");

            migrationBuilder.DropTable(
                name: "aspnet_Paths");

            migrationBuilder.DropTable(
                name: "aspnet_Roles");

            migrationBuilder.DropTable(
                name: "aspnet_Users");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "BulkImportPeople");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "aspnet_Applications");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Stimuli");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TestCategories");

            migrationBuilder.DropTable(
                name: "TestSecurityLevels");

            migrationBuilder.DropTable(
                name: "TestTypes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "StimulusTypes");

            migrationBuilder.DropTable(
                name: "Centers");

            migrationBuilder.DropTable(
                name: "CenterTypes");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
