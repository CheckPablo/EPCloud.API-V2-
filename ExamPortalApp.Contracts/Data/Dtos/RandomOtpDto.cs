using ExamPortalApp.Contracts.Data.Dtos;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class RandomOtpDto : EntityBase
{
    public int Otp { get; set; }

    public DateTime? OtpexpiryDate { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public int CenterId { get; set; }

    public int? TestId { get; set; }

    public int? SectorId { get; set; }

    public int? SubjectId { get; set; }

    public int? OldTestId { get; set; }

    public int? OldSectorId { get; set; }

    public int? OldSubjectId { get; set; }

    public CenterDto Center { get; set; } = null!;

    public GradeDto? Sector { get; set; }

    public SubjectDto? Subject { get; set; }

    public TestDto? Test { get; set; }
}
