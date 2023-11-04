namespace ExamPortalApp.Contracts.Data.Entities;

public partial class TestSecurityLevel : EntityBase
{
    public string? Description { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
