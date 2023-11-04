namespace ExamPortalApp.Contracts.Data.Entities;

public partial class InvigilatorStudentLink : EntityBase
{
    public DateTime? DateModifed { get; set; }

    public int? InvigilatorId { get; set; }

    public int? StudentId { get; set; }

    public int? OldStudentId { get; set; }

    public virtual Student? Student { get; set; }
}
