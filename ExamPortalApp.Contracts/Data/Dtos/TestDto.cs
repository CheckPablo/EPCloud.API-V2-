using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Dtos;

public partial class TestDto: EntityBase
{
    public DateTime? PaperExpiryDate { get; set; }

    public string? Code { get; set; }

    public string? TestName { get; set; }

    public string? TestIntro { get; set; }

    public string? TestDuration { get; set; }

    public DateTime? TestCreated { get; set; }

    public DateTime? ExamDate { get; set; }

    public int? LanguageId { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Tts { get; set; }

    public bool? WorkOffline { get; set; }

    public int? TestSecurityLevelId { get; set; }

    public bool? AnswerScanningAvailable { get; set; }

    public int? SubjectId { get; set; }

    public int? SectorId { get; set; }

    public int? ExamId { get; set; }

    public int? TestTypeId { get; set; }

    public int? TestCategoryId { get; set; }

    public int? AlternateTestId { get; set; }

    public int? CenterId { get; set; }

    public int? OldSubjectId { get; set; }

    public int? OldSectorId { get; set; }

    public int? OldCenterId { get; set; }

    public virtual CenterDto? Center { get; set; }

    public virtual LanguageDto? Language { get; set; }

    public virtual GradeDto? Sector { get; set; }

    public virtual SubjectDto? Subject { get; set; }

    public virtual TestCategoryDto? TestCategory { get; set; }

    public virtual TestSecurityLevelDto? TestSecurityLevel { get; set; }

    public virtual TestTypeDto? TestType { get; set; }
}
