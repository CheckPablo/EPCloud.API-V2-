namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Test : EntityBase
{
    public DateTime? PaperExpiryDate { get; set; }

    public string? Code { get; set; }

    public string? FileName { get; set; }

    public string? TestName { get; set; }

    //public byte[]? TestDocument { get; set; }

    public string? TestIntro { get; set; }

    public string? TestDuration { get; set; }

    public DateTime? TestCreated { get; set; }

    public DateTime? ExamDate { get; set; }

    public int? LanguageId { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Tts { get; set; }

    public bool? WorkOffline { get; set; }

    public int? TestSecurityLevelId { get; set; }

    public bool? AnswerScanningAvailable { get; set; }

    public int? SubjectId { get; set; }

    public int? SectorId { get; set; }

    public int? ExamId { get; set; }

    public int? TestTypeId { get; set; }

    public int? TestCategoryId { get; set; }

    public int? AlternateTestId { get; set; }

    public int? CenterId { get; set; }

    public int? OldSubjectId { get; set; }

    public int? OldSectorId { get; set; }

    public int? OldCenterId { get; set; }

    public byte[]? IV { get; set; }

    public byte[]? EncryptionKey { get; set; }

    public virtual Language? Language { get; set; }

    public virtual Grade? Sector { get; set; }

    public virtual Center? Center { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual TestCategory? TestCategory { get; set; }

    public virtual TestSecurityLevel? TestSecurityLevel { get; set; }

    public virtual TestType? TestType { get; set; }

    public virtual ICollection<Assessment> Assessments { get; } = new List<Assessment>();

    public virtual ICollection<DisclaimerAccept> DisclaimerAccepts { get; } = new List<DisclaimerAccept>();

    public virtual ICollection<Irregularity> Irregularities { get; } = new List<Irregularity>();

    public virtual ICollection<KeyPressTracking> KeyPressTrackings { get; } = new List<KeyPressTracking>();

    public virtual ICollection<RandomOtp> RandomOtps { get; } = new List<RandomOtp>();

    public virtual ICollection<Screenshot> Screenshots { get; } = new List<Screenshot>();

    public virtual ICollection<StudentTestLog> StudentTestLogs { get; } = new List<StudentTestLog>();

    public virtual ICollection<StudentTest> StudentTests { get; } = new List<StudentTest>();

    public virtual ICollection<TestQuestion> TestQuestions { get; } = new List<TestQuestion>();

    public virtual ICollection<UploadedSourceDocument> UploadedSourceDocuments { get; } = new List<UploadedSourceDocument>();

    public virtual ICollection<UserDocumentAnswer> UserDocumentAnswers { get; } = new List<UserDocumentAnswer>();

    public virtual ICollection<UserDocumentAnswersBackup> UserDocumentAnswersBackups { get; } = new List<UserDocumentAnswersBackup>();

    public virtual ICollection<UserScannedImage> UserScannedImages { get; } = new List<UserScannedImage>();
}
