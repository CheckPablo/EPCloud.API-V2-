using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Student : EntityBase
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string ExamNo { get; set; } = null!;

    public string? IdNumber { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public bool? Updated { get; set; }

    public bool? IsOnline { get; set; }

    public byte[]? PasswordEncrypted { get; set; }
    
    public string? EncrytedPassword { get; set; }

    public Guid? Salt { get; set; }

    public string? StudentNo { get; set; }

    public string? EmailAddress { get; set; }

    public string? ContactNo { get; set; }

    public bool? SentConfirmation { get; set; }

    public int? CertLangId { get; set; }

    public int? CenterId { get; set; }

    public int? GradeId { get; set; }

    public int? RegionId { get; set; }

    public int? OldRegionId { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }
    public string? ExternalEmail { set; get; }

    public bool? EligibleForExternalLogin { set; get; }

    [NotMapped]
    public string PlainPassword { get; set; } = string.Empty;

    [NotMapped]
    public string GradeCode { get; set; } = string.Empty;

    public virtual ICollection<StudentSubject> StudentSubjects { get; } = new List<StudentSubject>();

    public virtual ICollection<Assessment> Assessments { get; } = new List<Assessment>();

    public virtual ICollection<BulkImportPerson> BulkImportPeople { get; } = new List<BulkImportPerson>();

    public virtual Center? Center { get; set; }

    public virtual Language? CertLang { get; set; }

    public virtual ICollection<DisclaimerAccept> DisclaimerAccepts { get; } = new List<DisclaimerAccept>();

    public virtual ICollection<InvigilatorStudentLink> InvigilatorStudentLinks { get; } = new List<InvigilatorStudentLink>();

    public virtual ICollection<Irregularity> Irregularities { get; } = new List<Irregularity>();

    public virtual ICollection<KeyPressTracking> KeyPressTrackings { get; } = new List<KeyPressTracking>();

    public virtual Region? Region { get; set; }

    public virtual ICollection<Screenshot> Screenshots { get; } = new List<Screenshot>();

    public virtual Grade? Grade { get; set; }

    public virtual ICollection<StudentRetriefe> StudentRetrieves { get; } = new List<StudentRetriefe>();

    public virtual ICollection<StudentTestLog> StudentTestLogs { get; } = new List<StudentTestLog>();

    public virtual ICollection<StudentTest> StudentTests { get; } = new List<StudentTest>();

    public virtual ICollection<UserDocumentAnswer> UserDocumentAnswers { get; } = new List<UserDocumentAnswer>();

    public virtual ICollection<UserDocumentAnswersBackup> UserDocumentAnswersBackups { get; } = new List<UserDocumentAnswersBackup>();

    public virtual ICollection<UserScannedImage> UserScannedImages { get; } = new List<UserScannedImage>();
}
