namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StudentTest : EntityBase
{
    public bool? Absent { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? ElectronicReader { get; set; }

    public bool? Accomodation { get; set; }

    public string? StudentExtraTime { get; set; }

    public string? LoginUid { get; set; }

    public bool? TestLoadedInBrowser { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? OldStudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
