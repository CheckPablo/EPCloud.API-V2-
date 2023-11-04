namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Province : EntityBase
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Center> Centers { get; } = new List<Center>();
}
