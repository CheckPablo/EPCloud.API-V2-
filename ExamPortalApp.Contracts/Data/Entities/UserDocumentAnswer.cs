namespace ExamPortalApp.Contracts.Data.Entities;

public partial class UserDocumentAnswer : EntityBase
{
    public string? FileName { get; set; }

    public byte[]? TestDocument { get; set; }

    public DateTime? TimeStamp { get; set; }

    public int? TestId { get; set; }

    public int StudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Test? Test { get; set; }
}
