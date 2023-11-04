namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StudentSubject : EntityBase
{
    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public int? OldSubjectId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual ICollection<BulkImportSectorSubject> BulkImportSectorSubjects { get; } = new List<BulkImportSectorSubject>();
}
