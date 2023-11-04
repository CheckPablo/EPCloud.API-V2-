namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Screenshot : EntityBase
{
    public byte[]? ScreenshotData { get; set; }

    public DateTime? DateModified { get; set; }

    public int? TestId { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
