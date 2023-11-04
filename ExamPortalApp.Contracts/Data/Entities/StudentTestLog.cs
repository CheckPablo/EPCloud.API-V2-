namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StudentTestLog : EntityBase
{
    public string? ProcessName { get; set; }

    public DateTime? ProcessDate { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? OldStudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
