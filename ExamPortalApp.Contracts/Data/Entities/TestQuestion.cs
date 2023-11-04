namespace ExamPortalApp.Contracts.Data.Entities;

public partial class TestQuestion : EntityBase
{
    public int? QuestionNo { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int TestId { get; set; }

    public int QuestionId { get; set; }

    public virtual ICollection<Assessment> Assessments { get; } = new List<Assessment>();

    public virtual Question Question { get; set; } = null!;

    public virtual Test Test { get; set; } = null!;
}
