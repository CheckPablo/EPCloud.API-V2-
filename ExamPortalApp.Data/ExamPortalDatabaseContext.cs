using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamPortalApp.Data
{
    public partial class ExamPortalDatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ExamPortalDatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        #region Tables
        public virtual DbSet<Answer> Answers { get; set; }

        public virtual DbSet<AnswerMultiple> AnswerMultiples { get; set; }

        public virtual DbSet<AnswerProgressTracking> AnswerProgressTrackings { get; set; }

        public virtual DbSet<AnswerText> AnswerTexts { get; set; }

        public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }

        public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }

        public virtual DbSet<AspnetPath> AspnetPaths { get; set; }

        public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

        public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

        public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

        public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

        public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

        public virtual DbSet<Assessment> Assessments { get; set; }

        public virtual DbSet<BckaStimulusText> BckaStimulusTexts { get; set; }

        public virtual DbSet<BcktQuestion> BcktQuestions { get; set; }

        public virtual DbSet<BufferATestQuestion> BufferATestQuestions { get; set; }

        public virtual DbSet<BufferTQuestion> BufferTQuestions { get; set; }

        public virtual DbSet<BulkImportPerson> BulkImportPeople { get; set; }

        public virtual DbSet<BulkImportSectorSubject> BulkImportSectorSubjects { get; set; }

        public virtual DbSet<Center> Centers { get; set; }

        public virtual DbSet<CenterType> CenterTypes { get; set; }

        public virtual DbSet<CenterTypes1> CenterTypes1s { get; set; }

        public virtual DbSet<DisclaimerAccept> DisclaimerAccepts { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<InvigilatorStudentLink> InvigilatorStudentLinks { get; set; }

        public virtual DbSet<Irregularity> Irregularities { get; set; }

        public virtual DbSet<KeyPressTracking> KeyPressTrackings { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Medium> Media { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<NumberOfCandidate> NumberOfCandidates { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<QuestionType> QuestionTypes { get; set; }

        public virtual DbSet<RandomOtp> RandomOtps { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Screenshot> Screenshots { get; set; }

        public virtual DbSet<SebSetting> SebSettings { get; set; }

        public virtual DbSet<Grade> Sectors { get; set; }

        public virtual DbSet<Stimulus> Stimuli { get; set; }

        public virtual DbSet<StimulusImage> StimulusImages { get; set; }

        public virtual DbSet<StimulusMedium> StimulusMedia { get; set; }

        public virtual DbSet<StimulusText> StimulusTexts { get; set; }

        public virtual DbSet<StimulusType> StimulusTypes { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentProgress> StudentProgresses { get; set; }

        public virtual DbSet<StudentProgressTestUpload> StudentProgressTestUploads { get; set; }

        public virtual DbSet<StudentRetriefe> StudentRetrieves { get; set; }

        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        public virtual DbSet<StudentTest> StudentTests { get; set; }

        public virtual DbSet<StudentTestLog> StudentTestLogs { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Target> Targets { get; set; }

        public virtual DbSet<Test> Tests { get; set; }

        public virtual DbSet<TestCategory> TestCategories { get; set; }

        public virtual DbSet<TestQuestion> TestQuestions { get; set; }

        public virtual DbSet<TestSecurityLevel> TestSecurityLevels { get; set; }

        public virtual DbSet<TestType> TestTypes { get; set; }

        public virtual DbSet<TmpBckasn> TmpBckasns { get; set; }

        public virtual DbSet<UploadedAnswerDocument> UploadedAnswerDocuments { get; set; }

        public virtual DbSet<UploadedSourceDocument> UploadedSourceDocuments { get; set; }

        public virtual DbSet<UploadedTest> UploadedTests { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserDocumentAnswer> UserDocumentAnswers { get; set; }

        public virtual DbSet<UserDocumentAnswersBackup> UserDocumentAnswersBackups { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<UserScannedImage> UserScannedImages { get; set; }

        public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

        public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

        public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

        public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

        public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

        public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

        public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

        public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

        public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
#else
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamPortalDatabaseContext).Assembly);

            modelBuilder.Entity<Answer>(builder =>
            {
                builder.HasIndex(e => e.AnswerId, "IX_Answers_AnswerId");

                builder.HasIndex(e => new { e.AnswerId, e.QuestionId }, "IX_Answers_AnswerId_QuestionId").IsUnique();

                builder.HasIndex(e => e.QuestionId, "IX_Answers_QuestionId");

                builder.HasIndex(e => new { e.QuestionId, e.AnswerId, e.AnswerDesc, e.OptionCode }, "IX_Answers_QuestionId_AnswerId_AnswerDesc_OptionCode");

                builder.Property(e => e.AnswerDesc).HasMaxLength(250);
                builder.Property(e => e.OptionCode).HasMaxLength(10);

                builder.HasOne(d => d.Question).WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Answers_Questions");
            });

            modelBuilder.Entity<AnswerProgressTracking>(builder =>
            {
                builder.HasIndex(e => new { e.TestId, e.StudentId }, "IX_AnswerProgressTrackings_TestId_StudentId");
            });

            modelBuilder.Entity<AspnetApplication>(builder =>
            {
                builder.HasKey(e => e.ApplicationId)
                    .HasName("PK__aspnet_A__C93A4C98CED8A85C")
                    .IsClustered(false);

                builder.ToTable("aspnet_Applications");

                builder.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE43F4045CA").IsUnique();

                builder.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__3091033139F4CAB8").IsUnique();

                builder.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index")
                    .IsClustered()
                    .HasFillFactor(90);

                builder.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
                builder.Property(e => e.ApplicationName).HasMaxLength(256);
                builder.Property(e => e.Description).HasMaxLength(256);
                builder.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetMembership>(builder =>
            {
                builder.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_M__1788CC4DCD837534")
                    .IsClustered(false);

                builder.ToTable("aspnet_Membership");

                builder.Property(e => e.UserId).ValueGeneratedNever();
                builder.Property(e => e.Comment).HasColumnType("ntext");
                builder.Property(e => e.CreateDate).HasColumnType("datetime");
                builder.Property(e => e.Email).HasMaxLength(256);
                builder.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
                builder.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
                builder.Property(e => e.LastLockoutDate).HasColumnType("datetime");
                builder.Property(e => e.LastLoginDate).HasColumnType("datetime");
                builder.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
                builder.Property(e => e.LoweredEmail).HasMaxLength(256);
                builder.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");
                builder.Property(e => e.Password).HasMaxLength(128);
                builder.Property(e => e.PasswordAnswer).HasMaxLength(128);
                builder.Property(e => e.PasswordSalt).HasMaxLength(128);

                builder.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__aspnet_Me__Appli__1387E197");

                builder.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                    .HasForeignKey<AspnetMembership>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__aspnet_Me__UserI__1293BD5E");
            });

            modelBuilder.Entity<AspnetPath>(builder =>
            {
                builder.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC58395E0EF9")
                    .IsClustered(false);

                builder.ToTable("aspnet_Paths");

                builder.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                    .IsUnique()
                    .IsClustered()
                    .HasFillFactor(90);

                builder.Property(e => e.PathId).HasDefaultValueSql("(newid())");
                builder.Property(e => e.LoweredPath).HasMaxLength(256);
                builder.Property(e => e.Path).HasMaxLength(256);

                builder.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__aspnet_Pa__Appli__1A34DF26");
            });

            modelBuilder.Entity<AspnetPersonalizationAllUser>(builder =>
            {
                builder.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC59EDC10811");

                builder.ToTable("aspnet_PersonalizationAllUsers");

                builder.Property(e => e.PathId).ValueGeneratedNever();
                builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                builder.Property(e => e.PageSettings).HasColumnType("image");

                builder.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
                    .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__aspnet_Pe__PathI__1C1D2798");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(builder =>
            {
                builder.HasKey(e => e.Id)
                    .HasName("PK__aspnet_P__3214EC06F3D7E7E5")
                    .IsClustered(false);

                builder.ToTable("aspnet_PersonalizationPerUser");

                builder.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                    .IsUnique()
                    .IsClustered()
                    .HasFillFactor(90);

                builder.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2")
                    .IsUnique()
                    .HasFillFactor(90);

                builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
                builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                builder.Property(e => e.PageSettings).HasColumnType("image");

                builder.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers)
                    .HasForeignKey(d => d.PathId)
                    .HasConstraintName("FK__aspnet_Pe__PathI__1E05700A");

                builder.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__aspnet_Pe__UserI__1EF99443");
            });

            modelBuilder.Entity<AspnetProfile>(builder =>
            {
                builder.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4CAF9D5AE4");

                builder.ToTable("aspnet_Profile");

                builder.Property(e => e.UserId).ValueGeneratedNever();
                builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                builder.Property(e => e.PropertyNames).HasColumnType("ntext");
                builder.Property(e => e.PropertyValuesBinary).HasColumnType("image");
                builder.Property(e => e.PropertyValuesString).HasColumnType("ntext");

                builder.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                    .HasForeignKey<AspnetProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__aspnet_Pr__UserI__21D600EE");
            });

            modelBuilder.Entity<AspnetRole>(builder =>
            {
                builder.HasKey(e => e.RoleId)
                    .HasName("PK__aspnet_R__8AFACE1BE0E47F96")
                    .IsClustered(false);

                builder.ToTable("aspnet_Roles");

                builder.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                    .IsUnique()
                    .IsClustered()
                    .HasFillFactor(90);

                builder.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
                builder.Property(e => e.Description).HasMaxLength(256);
                builder.Property(e => e.LoweredRoleName).HasMaxLength(256);
                builder.Property(e => e.RoleName).HasMaxLength(256);

                builder.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__23BE4960");
            });

            modelBuilder.Entity<AspnetSchemaVersion>(builder =>
            {
                builder.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC1BD356993");

                builder.ToTable("aspnet_SchemaVersions");

                builder.Property(e => e.Feature).HasMaxLength(128);
                builder.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetUser>(builder =>
            {
                builder.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_U__1788CC4DDBEBEFD3")
                    .IsClustered(false);

                builder.ToTable("aspnet_Users");

                builder.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                    .IsUnique()
                    .IsClustered()
                    .HasFillFactor(90);

                builder.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2").HasFillFactor(90);

                builder.Property(e => e.UserId).HasDefaultValueSql("(newid())");
                builder.Property(e => e.LastActivityDate).HasColumnType("datetime");
                builder.Property(e => e.LoweredUserName).HasMaxLength(256);
                builder.Property(e => e.MobileAlias).HasMaxLength(16);
                builder.Property(e => e.UserName).HasMaxLength(256);

                builder.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__aspnet_Us__Appli__25A691D2");

                builder.HasMany(d => d.Roles).WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspnetUsersInRole",
                        r => r.HasOne<AspnetRole>().WithMany()
                            .HasForeignKey("RoleId")
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("FK__aspnet_Us__RoleI__278EDA44"),
                        l => l.HasOne<AspnetUser>().WithMany()
                            .HasForeignKey("UserId")
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("FK__aspnet_Us__UserI__2882FE7D"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__aspnet_U__AF2760AD5F7251C8");
                            j.ToTable("aspnet_UsersInRoles");
                            j.HasIndex(new[] { "RoleId" }, "aspnet_UsersInRoles_index").HasFillFactor(90);
                        });
            });

            modelBuilder.Entity<Assessment>(builder =>
            {
                builder.HasOne(d => d.Student).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Assessments_Students");

                builder.HasOne(d => d.Subject).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Assessments_Subjects");

                builder.HasOne(d => d.Test).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_Assessments_Tests");

                builder.HasOne(d => d.TestQuestion).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.TestQuestionId)
                    .HasConstraintName("FK_Assessments_TestQuestions");
            });

            modelBuilder.Entity<BckaStimulusText>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToTable("bckaStimulusText");

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.StimulusId).HasColumnName("StimulusID");
                builder.Property(e => e.StimulusText).IsUnicode(false);
                builder.Property(e => e.StimulusTextId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("StimulusTextID");
            });

            modelBuilder.Entity<BcktQuestion>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToTable("bcktQuestion");

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.NoteId)
                    .IsUnicode(false)
                    .HasColumnName("NoteID");
                builder.Property(e => e.QuestionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                builder.Property(e => e.QuestionId).HasColumnName("QuestionID");
                builder.Property(e => e.QuestionInstruction).IsUnicode(false);
                builder.Property(e => e.QuestionStem).IsUnicode(false);
                builder.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");
                builder.Property(e => e.StimulusId).HasColumnName("StimulusID");
            });

            modelBuilder.Entity<BufferATestQuestion>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToTable("buffer_aTestQuestion");

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.QuestionId).HasColumnName("QuestionID");
                builder.Property(e => e.TestId).HasColumnName("TestID");
                builder.Property(e => e.TestQuestionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TestQuestionID");
            });

            modelBuilder.Entity<BufferTQuestion>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToTable("buffer_tQuestion");

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.NoteId)
                    .IsUnicode(false)
                    .HasColumnName("NoteID");
                builder.Property(e => e.QuestionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                builder.Property(e => e.QuestionId).HasColumnName("QuestionID");
                builder.Property(e => e.QuestionInstruction).IsUnicode(false);
                builder.Property(e => e.QuestionStem).IsUnicode(false);
                builder.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");
                builder.Property(e => e.StimulusId).HasColumnName("StimulusID");
            });

            modelBuilder.Entity<BulkImportPerson>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__BulkImportPeople");

                builder.Property(e => e.BatchId).HasMaxLength(128);
                builder.Property(e => e.CellPhone)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.IdNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.ImportDate).HasColumnType("datetime");
                builder.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.StudentNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Surname)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                builder.HasOne(d => d.Student).WithMany(p => p.BulkImportPeople)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_BulkImportPeople_Students");
            });

            modelBuilder.Entity<BulkImportSectorSubject>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__BulkImportSectorSubject");

                builder.Property(e => e.BatchId).HasMaxLength(128);
                builder.Property(e => e.ImportDate).HasColumnType("datetime");
                builder.Property(e => e.Sector)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.SectorCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.StudentNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Subject)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.SubjectCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                builder.HasOne(d => d.BulkImport).WithMany(p => p.BulkImportSectorSubjects)
                    .HasForeignKey(d => d.BulkImportId)
                    .HasConstraintName("FK__BulkImpor__BulkI__0C90CB45");

                builder.HasOne(d => d.SectorNavigation).WithMany(p => p.BulkImportSectorSubjects)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_BulkImportSectorSubjects_Sectors");

                builder.HasOne(d => d.StudentSubject).WithMany(p => p.BulkImportSectorSubjects)
                    .HasForeignKey(d => d.StudentSubjectId)
                    .HasConstraintName("FK_BulkImportSectorSubjects_StudentSubjects");

                builder.HasOne(d => d.SubjectNavigation).WithMany(p => p.BulkImportSectorSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_BulkImportSectorSubjects_Subjects");
            });

            modelBuilder.Entity<Center>(builder =>
            {
                builder.Property(e => e.AttendanceRegisterPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                builder.Property(e => e.Disclaimer).IsUnicode(false);
                builder.Property(e => e.ExpiryDate).HasColumnType("date");
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                builder.Property(e => e.Prefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.HasOne(d => d.CenterType)
                    .WithMany(p => p.Centers)
                    .HasForeignKey(d => d.CenterTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Centers_CenterTypes");

                builder.HasOne(d => d.Province)
                    .WithMany(p => p.Centers)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Centers_Provinces");
            });

            modelBuilder.Entity<CenterType>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__CenterTypes");

                builder.Property(e => e.Description)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CenterTypes1>(builder =>
            {
                builder.HasKey(e => e.CenterTypeId).HasName("PK__lCenterT__790E764CE79327AC");

                builder.ToTable("CenterTypes1");

                builder.Property(e => e.CenterTypeId).HasColumnName("CenterTypeID");
                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DisclaimerAccept>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__DisclaimerAccepts");

                builder.HasIndex(e => new { e.TestId, e.StudentId }, "IX_TestId_StudentId");

                builder.Property(e => e.DateModified).HasColumnType("datetime");

                builder.HasOne(d => d.Student).WithMany(p => p.DisclaimerAccepts)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_DisclaimerAccepts_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.DisclaimerAccepts)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_DisclaimerAccepts_Tests");
            });

            modelBuilder.Entity<Image>(builder =>
            {
                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.PhysicalFile).HasColumnType("image");
            });

            modelBuilder.Entity<InvigilatorStudentLink>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__InvigilatorStudentLinks");

                builder.HasIndex(e => new { e.InvigilatorId, e.StudentId }, "IX_InvigilatorId_StudentId");

                builder.Property(e => e.DateModifed).HasColumnType("datetime");

                builder.HasOne(d => d.Student).WithMany(p => p.InvigilatorStudentLinks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_InvigilatorStudentLinks_Students");
            });

            modelBuilder.Entity<Irregularity>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__Irregula__269B16718B26737B");

                builder.HasIndex(e => new { e.TestId, e.StudentId }, "IDXTest_StudentID");

                builder.Property(e => e.DateModifed).HasColumnType("datetime");

                builder.HasOne(d => d.Student).WithMany(p => p.Irregularities)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Irregularities_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.Irregularities)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_Irregularities_Tests");
            });

            modelBuilder.Entity<KeyPressTracking>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_KeyPress");

                builder.HasIndex(e => new { e.StudentId, e.TestId }, "IX_StudentId_TestId");

                builder.Property(e => e.DateModified).HasColumnType("datetime");
                builder.Property(e => e.Event)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                builder.Property(e => e.Reason).IsUnicode(false);

                builder.HasOne(d => d.Student).WithMany(p => p.KeyPressTrackings)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_KeyPressTrackings_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.KeyPressTrackings)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_KeyPressTrackings_Tests");
            });

            modelBuilder.Entity<Language>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__lLanguag__B938558B8A2A6A32");

                builder.Property(e => e.Code)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Medium>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_tMedia");

                builder.HasIndex(e => e.Id, "MediaID").HasFillFactor(90);

                builder.HasIndex(e => e.Removed, "Removed").HasFillFactor(90);

                builder.Property(e => e.Id).ValueGeneratedNever();
                builder.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Note>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__tNote__EACE357F11F1BBF1");

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<NumberOfCandidate>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__NumberOf__3214EC279D35C5E6");

                builder.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Province>(builder =>
            {
                builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<Question>(builder =>
            {
                builder.HasIndex(e => new { e.Id, e.StimulusId }, "IX_Questions_Id_StimulusId");

                builder.Property(e => e.QuestionCode).HasMaxLength(10);

                builder.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_Questions_QuestionTypes");

                builder.HasOne(d => d.Stimulus).WithMany(p => p.Questions)
                    .HasForeignKey(d => d.StimulusId)
                    .HasConstraintName("FK_Questions_Stimuli");
            });

            modelBuilder.Entity<QuestionType>(builder =>
            {
                builder.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<RandomOtp>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_RandomOTP");

                builder.ToTable("RandomOTPs");

                builder.HasIndex(e => new { e.CenterId, e.SectorId, e.SubjectId, e.TestId }, "IX_RandomOTPs");

                builder.HasIndex(e => e.Otp, "NonClusteredIndex-OTP");

                builder.Property(e => e.DateModified).HasColumnType("datetime");
                builder.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.Otp).HasColumnName("OTP");
                builder.Property(e => e.OtpexpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("OTPExpiryDate");

                builder.HasOne(d => d.Center).WithMany(p => p.RandomOtps)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RandomOTPs_Centers");

                builder.HasOne(d => d.Sector).WithMany(p => p.RandomOtps)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_RandomOTPs_Sectors");

                builder.HasOne(d => d.Subject).WithMany(p => p.RandomOtps)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_RandomOTPs_Subjects");

                builder.HasOne(d => d.Test).WithMany(p => p.RandomOtps)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_RandomOTPs_Tests");
            });

            modelBuilder.Entity<Rating>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__lRating__FCCDF85CDE2A2ED2");

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Region>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__Region__ACD844430335FEC3");

                builder.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(builder =>
            {
                builder.Property(e => e.Id).ValueGeneratedNever();
                builder.Property(e => e.RoleDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                builder.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Screenshot>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__Screensh__DFD702D8B6DF1F20");

                builder.Property(e => e.DateModified).HasColumnType("datetime");

                builder.HasOne(d => d.Student).WithMany(p => p.Screenshots)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Screenshots_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.Screenshots)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_Screenshots_Tests");
            });

            modelBuilder.Entity<SebSetting>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__SEBsetti__174A327D1D94BAF0");

                builder.Property(e => e.HashDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.MacSebsettings)
                    .IsUnicode(false)
                    .HasColumnName("MacSEBSettings");
                builder.Property(e => e.Sebsettings)
                    .IsUnicode(false)
                    .HasColumnName("SEBSettings");
            });

            modelBuilder.Entity<Grade>(builder =>
            {
                builder.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

                builder.HasOne(d => d.Center).WithMany(p => p.Sectors)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("FK_Sectors_Centers");
            });

            modelBuilder.Entity<Stimulus>(builder =>
            {
                builder.HasIndex(e => e.HasImage, "HasImage").HasFillFactor(90);

                builder.HasIndex(e => e.Removed, "Removed").HasFillFactor(90);

                builder.HasIndex(e => e.SectionId, "SectionID").HasFillFactor(90);

                builder.HasIndex(e => e.SectorId, "SectorID").HasFillFactor(90);

                builder.HasIndex(e => e.Id, "StimulusID").HasFillFactor(90);

                builder.HasIndex(e => e.StimulusTypeId, "StimulusTypeID").HasFillFactor(90);

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.StimulusInstruction).IsUnicode(false);

                builder.HasOne(d => d.Sector).WithMany(p => p.Stimuli)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Stimuli_Sectors");

                builder.HasOne(d => d.StimulusType).WithMany(p => p.Stimuli)
                    .HasForeignKey(d => d.StimulusTypeId)
                    .HasConstraintName("FK_Stimuli_StimulusTypes");
            });

            modelBuilder.Entity<StimulusImage>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_aStimulusImage");

                builder.HasIndex(e => new { e.ImageId, e.StimulusId }, "IX_StimulusImages").IsUnique();

                builder.HasIndex(e => e.ImageId, "ImageID").HasFillFactor(90);

                builder.HasIndex(e => e.Removed, "Removed").HasFillFactor(90);

                builder.HasIndex(e => e.StimulusId, "StimulusID").HasFillFactor(90);

                builder.HasIndex(e => e.Id, "UQ__aStimulu__1619A5C21C2B9801").IsUnique();

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

                builder.HasOne(d => d.Image).WithMany(p => p.StimulusImages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_StimulusImages_Images");

                builder.HasOne(d => d.Stimulus).WithMany(p => p.StimulusImages)
                    .HasForeignKey(d => d.StimulusId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_StimulusImages_Stimuli");
            });

            modelBuilder.Entity<StimulusMedium>(builder =>
            {
                builder.HasIndex(e => new { e.MediaId, e.StimulusId }, "IX_StimulusMedia").IsUnique();

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

                builder.HasOne(d => d.Media).WithMany(p => p.StimulusMedia)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_StimulusMedia_Media");

                builder.HasOne(d => d.Stimulus).WithMany(p => p.StimulusMedia)
                    .HasForeignKey(d => d.StimulusId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_StimulusMedia_Stimuli");
            });

            modelBuilder.Entity<StimulusText>(builder =>
            {
                builder.HasIndex(e => e.StimulusId, "IX_StimulusText").HasFillFactor(90);

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.StimulusText1).HasColumnName("StimulusText");

                builder.HasOne(d => d.Stimulus).WithMany(p => p.StimulusTexts)
                    .HasForeignKey(d => d.StimulusId)
                    .HasConstraintName("FK_StimulusTexts_Stimuli");
            });

            modelBuilder.Entity<StimulusType>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__lStimulu__0C07AF7C36E62C1B");

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_Student");

                builder.HasIndex(e => e.CenterId, "CenterID").HasFillFactor(90);

                builder.HasIndex(e => e.Name, "IDXName");

                builder.HasIndex(e => e.GradeId, "IDXSector");

                builder.HasIndex(e => e.Removed, "Remove").HasFillFactor(90);

                builder.HasIndex(e => e.Id, "StudentID").HasFillFactor(90);

                builder.HasIndex(e => e.Updated, "Update").HasFillFactor(90);

                builder.HasIndex(e => e.Id, "_dta_index_tStudent_18_1778105375__K1_4").HasFillFactor(90);

                builder.Property(e => e.ContactNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                builder.Property(e => e.EmailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                builder.Property(e => e.ExamNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.IdNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                builder.Property(e => e.PasswordEncrypted)
                    .HasMaxLength(64)
                    .IsFixedLength();
                builder.Property(e => e.StudentNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.HasOne(d => d.Center).WithMany(p => p.Students)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("FK_Students_Centers");

                builder.HasOne(d => d.CertLang).WithMany(p => p.Students)
                    .HasForeignKey(d => d.CertLangId)
                    .HasConstraintName("FK_Students_Languages");

                builder.HasOne(d => d.Region).WithMany(p => p.Students)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Students_Regions");

                builder.HasOne(d => d.Grade).WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_Students_Sectors");
            });

            modelBuilder.Entity<StudentProgress>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__tStudent__C7ABDEA89BCCDEA2");

                builder.ToTable("StudentProgress");

                builder.HasIndex(e => new { e.StudentId, e.TestId, e.QuestionId, e.AnswerId }, "IX_StudentProgress").IsUnique();

                builder.HasIndex(e => new { e.TestId, e.StudentId }, "_dta_index_tStudentProgress_18_1563152614__K3_K2").HasFillFactor(90);

                builder.HasIndex(e => new { e.TestId, e.StudentId, e.QuestionId, e.AnswerId, e.Id }, "_dta_index_tStudentProgress_18_1563152614__K3_K2_K4_K7_K1").HasFillFactor(90);

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.TimeRemaining)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentProgressTestUpload>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__tStudent__C7ABDEA8CAF79D33");

                builder.HasIndex(e => new { e.StudentId, e.TestId }, "IDXStudent_TestID");

                builder.HasIndex(e => new { e.TestId, e.StudentId }, "IX_StudentProgressTestUploads").IsUnique();

                builder.Property(e => e.EndTime).HasColumnType("datetime");
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.StartTime).HasColumnType("datetime");
                builder.Property(e => e.StudentExtraTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                builder.Property(e => e.TimeRemaining)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentRetriefe>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__StudentP__87F839308898F770");

                builder.HasIndex(e => e.StudentId, "IDXStudentID");

                builder.Property(e => e.CreatedDate).HasColumnType("datetime");
                builder.Property(e => e.EncryptedText).HasMaxLength(200);

                builder.HasOne(d => d.Student).WithMany(p => p.StudentRetrieves)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentRetrieves_Students");
            });

            modelBuilder.Entity<StudentSubject>(builder =>
            {
                builder.HasIndex(e => new { e.StudentId, e.SubjectId })
                    .IsUnique();

                builder.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull);

                builder.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<StudentTest>(builder =>
            {
                builder.HasIndex(e => new { e.StudentId, e.TestId }, "IX_StudentTests");

                builder.Property(e => e.EndDate).HasColumnType("datetime");
                builder.Property(e => e.LoginUid).HasMaxLength(128);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.StartDate).HasColumnType("datetime");
                builder.Property(e => e.StudentExtraTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.HasOne(d => d.Student).WithMany(p => p.StudentTests)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentTests_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.StudentTests)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_StudentTests_Tests");
            });

            modelBuilder.Entity<StudentTestLog>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_StudentTestLog");

                builder.Property(e => e.ProcessDate).HasColumnType("datetime");
                builder.Property(e => e.ProcessName).HasMaxLength(50);

                builder.HasOne(d => d.Student).WithMany(p => p.StudentTestLogs)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentTestLogs_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.StudentTestLogs)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_StudentTestLogs_Tests");
            });

            modelBuilder.Entity<Subject>(builder =>
            {
                builder.HasKey(e => e.Id)
                    .HasName("PK_lSubject")
                    .IsClustered(false);

                builder.HasIndex(e => e.Id, "PKSubjectID")
                    .IsUnique()
                    .IsClustered();

                builder.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                builder.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Target>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__lTarget__2B1F0FB64734E311");

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Test>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_tTest");

                builder.HasIndex(e => new { e.Id, e.SubjectId, e.ExamId, e.CenterId }, "NonClusteredIndex-20200723-181115");

                builder.HasIndex(e => e.PaperExpiryDate, "NonClusteredIndex-20210726-134543");

                builder.HasIndex(e => e.Id, "_dta_index_tTest_18_151671588__K1").HasFillFactor(90);

                builder.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                builder.Property(e => e.DateModified).HasColumnType("datetime");
                builder.Property(e => e.ExamDate).HasColumnType("datetime");
                builder.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.PaperExpiryDate).HasColumnType("datetime");
                builder.Property(e => e.TestCreated).HasColumnType("datetime");
                builder.Property(e => e.TestDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.TestIntro).IsUnicode(false);
                builder.Property(e => e.TestName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                builder.HasOne(d => d.Center).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("FK_Tests_Centers");

                builder.HasOne(d => d.Language).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Tests_Languages");

                builder.HasOne(d => d.Sector).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_Tests_Sectors");

                builder.HasOne(d => d.Subject).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Tests_Subjects");

                builder.HasOne(d => d.TestCategory).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.TestCategoryId)
                    .HasConstraintName("FK_Tests_TestCategories");

                builder.HasOne(d => d.TestSecurityLevel).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.TestSecurityLevelId)
                    .HasConstraintName("FK_Tests_TestSecurityLevels");

                builder.HasOne(d => d.TestType).WithMany(p => p.Tests)
                    .HasForeignKey(d => d.TestTypeId)
                    .HasConstraintName("FK_Tests_TestTypes");
            });

            modelBuilder.Entity<TestCategory>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__lTestCat__2CE3751DC4238E9D");

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestQuestion>(builder =>
            {
                builder.HasIndex(e => new { e.TestId, e.Id }, "IX_TestQuestions");

                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

                builder.HasOne(d => d.Question).WithMany(p => p.TestQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TestQuestions_Questions");

                builder.HasOne(d => d.Test).WithMany(p => p.TestQuestions)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TestQuestions_Tests");
            });

            modelBuilder.Entity<TestSecurityLevel>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__TestSecu__4064EDEA36A11696");

                builder.Property(e => e.DateModified).HasColumnType("datetime");
                builder.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestType>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__lTestTyp__9BB87646E25BCB6F");

                builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TmpBckasn>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToTable("tmpBCKasns");

                builder.Property(e => e.AnswerId).HasColumnName("AnswerID");
                builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
                builder.Property(e => e.StudentId).HasColumnName("StudentID");
                builder.Property(e => e.StudentProgressId).HasColumnName("StudentProgressID");
                builder.Property(e => e.TestId).HasColumnName("TestID");
                builder.Property(e => e.TestQuestionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TestQuestionID");
                builder.Property(e => e.TimeRemaining)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<UploadedAnswerDocument>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__tUploade__A693271ADC4F3997");

                builder.HasIndex(e => e.TestId, "IX_tUploadedAnswerDocument");

                builder.Property(e => e.DateModified).HasColumnType("datetime");
                builder.Property(e => e.FileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UploadedSourceDocument>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__tUploade__1ABEEF6FCC72D0BF");

                builder.HasIndex(e => e.TestId, "IDXTestID");

                builder.Property(e => e.DateModified).HasColumnType("datetime");
                builder.Property(e => e.FileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                builder.HasOne(d => d.Test).WithMany(p => p.UploadedSourceDocuments)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_UploadedSourceDocuments_Tests");
            });

            modelBuilder.Entity<UploadedTest>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_tUploadedTest");

                builder.Property(e => e.Id).ValueGeneratedNever();
                builder.Property(e => e.FileName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.Property(e => e.ContactDetails)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                builder.Property(e => e.Modified).HasColumnType("datetime");
                builder.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Surname)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.UserEmailAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                builder.Property(e => e.Username)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                builder.HasOne(d => d.Center).WithMany(p => p.Users)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Users_Centers");

                builder.HasOne(d => d.CenterType).WithMany(p => p.Users)
                    .HasForeignKey(d => d.CenterTypeId)
                    .HasConstraintName("FK_Users_CenterTypes");
            });

            modelBuilder.Entity<UserDocumentAnswer>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK__tbUserDo__40A359E395DBA442");

                builder.HasIndex(e => new { e.TestId, e.StudentId }, "IDXStudent_TestID");

                builder.Property(e => e.FileName)
                    .HasMaxLength(350)
                    .IsUnicode(false);
                builder.Property(e => e.TimeStamp).HasColumnType("datetime");

                builder.HasOne(d => d.Student).WithMany(p => p.UserDocumentAnswers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserDocumentAnswers_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.UserDocumentAnswers)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_UserDocumentAnswers_Tests");
            });

            modelBuilder.Entity<UserDocumentAnswersBackup>(builder =>
            {
                builder.Property(e => e.FileName)
                    .HasMaxLength(350)
                    .IsUnicode(false);
                builder.Property(e => e.TimeStamp).HasColumnType("datetime");

                builder.HasOne(d => d.Student).WithMany(p => p.UserDocumentAnswersBackups)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_UserDocumentAnswersBackups_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.UserDocumentAnswersBackups)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_UserDocumentAnswersBackups_Tests");
            });

            modelBuilder.Entity<UserRole>(builder =>
            {
                builder.HasOne(d => d.Center).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("FK_UserRoles_Centers");

                builder.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRoles_Roles");

                builder.HasOne(d => d.User).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<UserScannedImage>(builder =>
            {
                builder.HasKey(e => e.Id).HasName("PK_tUserScannedImage");

                builder.HasIndex(e => new { e.StudentId, e.TestId, e.Otp }, "IX_Student_Test");

                builder.Property(e => e.Complete).HasDefaultValueSql("((0))");
                builder.Property(e => e.ExpiryDate).HasColumnType("datetime");
                builder.Property(e => e.Otp)
                    .HasMaxLength(50)
                    .HasColumnName("OTP");

                builder.HasOne(d => d.Student).WithMany(p => p.UserScannedImages)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_UserScannedImages_Students");

                builder.HasOne(d => d.Test).WithMany(p => p.UserScannedImages)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_UserScannedImages_Tests");
            });

            modelBuilder.Entity<VwAspnetApplication>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_Applications");

                builder.Property(e => e.ApplicationName).HasMaxLength(256);
                builder.Property(e => e.Description).HasMaxLength(256);
                builder.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetMembershipUser>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_MembershipUsers");

                builder.Property(e => e.Comment).HasColumnType("ntext");
                builder.Property(e => e.CreateDate).HasColumnType("datetime");
                builder.Property(e => e.Email).HasMaxLength(256);
                builder.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
                builder.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
                builder.Property(e => e.LastActivityDate).HasColumnType("datetime");
                builder.Property(e => e.LastLockoutDate).HasColumnType("datetime");
                builder.Property(e => e.LastLoginDate).HasColumnType("datetime");
                builder.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
                builder.Property(e => e.LoweredEmail).HasMaxLength(256);
                builder.Property(e => e.MobileAlias).HasMaxLength(16);
                builder.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");
                builder.Property(e => e.PasswordAnswer).HasMaxLength(128);
                builder.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetProfile>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_Profiles");

                builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetRole>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_Roles");

                builder.Property(e => e.Description).HasMaxLength(256);
                builder.Property(e => e.LoweredRoleName).HasMaxLength(256);
                builder.Property(e => e.RoleName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUser>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_Users");

                builder.Property(e => e.LastActivityDate).HasColumnType("datetime");
                builder.Property(e => e.LoweredUserName).HasMaxLength(256);
                builder.Property(e => e.MobileAlias).HasMaxLength(16);
                builder.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUsersInRole>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_UsersInRoles");
            });

            modelBuilder.Entity<VwAspnetWebPartStatePath>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_WebPartState_Paths");

                builder.Property(e => e.LoweredPath).HasMaxLength(256);
                builder.Property(e => e.Path).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetWebPartStateShared>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_WebPartState_Shared");

                builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetWebPartStateUser>(builder =>
            {
                builder
                    .HasNoKey()
                    .ToView("vw_aspnet_WebPartState_User");

                builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
