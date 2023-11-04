namespace ExamPortalApp.Contracts.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
public partial class Subject : EntityBase
{
    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int SectorId { get; set; }

    [NotMapped]
    public string? SubjectGrade { get; set; }

    public virtual ICollection<Assessment> Assessments { get; } = new List<Assessment>();

    public virtual ICollection<BulkImportSectorSubject> BulkImportSectorSubjects { get; } = new List<BulkImportSectorSubject>();

    public virtual ICollection<RandomOtp> RandomOtps { get; } = new List<RandomOtp>();

    public virtual ICollection<StudentSubject> StudentSubjects { get; } = new List<StudentSubject>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
