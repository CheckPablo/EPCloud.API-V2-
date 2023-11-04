namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Language : EntityBase
{
    public string? Description { get; set; }

    public string? Code { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
