namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Irregularity : EntityBase
{
    public bool? KeyPress { get; set; }

    public bool? LeftExamArea { get; set; }

    public bool? Offline { get; set; }

    public bool? FullScreenClosed { get; set; }

    public DateTime? DateModifed { get; set; }

    public int? TestId { get; set; }

    public int? StudentId { get; set; }

    public int? OldStudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
