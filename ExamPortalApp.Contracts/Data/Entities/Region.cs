namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Region : EntityBase
{
    public string? Description { get; set; }

    public int? CenterId { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
