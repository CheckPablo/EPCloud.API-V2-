namespace ExamPortalApp.Contracts.Data.Entities;

public partial class KeyPressTracking : EntityBase
{
    public string? Event { get; set; }

    public string? Reason { get; set; }

    public DateTime? DateModified { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? OldStudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
