namespace ExamPortalApp.Contracts.Data.Entities;

public partial class TestType : EntityBase
{
    public string? Description { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
