namespace ExamPortalApp.Contracts.Data.Entities;

public partial class CenterType : EntityBase
{
    public string? Description { get; set; }

    public virtual ICollection<Center> Centers { get; } = new List<Center>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
