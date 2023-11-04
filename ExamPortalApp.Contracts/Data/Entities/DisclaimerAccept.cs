namespace ExamPortalApp.Contracts.Data.Entities;

public partial class DisclaimerAccept : EntityBase
{
    public bool? Accepted { get; set; }

    public DateTime? DateModified { get; set; }

    public int? TestId { get; set; }

    public int? StudentId { get; set; }

    public int? OldTestId { get; set; }

    public int? OldStudentId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
