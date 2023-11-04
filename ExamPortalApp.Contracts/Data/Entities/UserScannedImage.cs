namespace ExamPortalApp.Contracts.Data.Entities;

public partial class UserScannedImage : EntityBase
{
    public string FileName { get; set; } = null!;

    public string? Otp { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? Complete { get; set; }

    public int? TestId { get; set; }

    public int? StudentId { get; set; }

    public int? OldStudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
