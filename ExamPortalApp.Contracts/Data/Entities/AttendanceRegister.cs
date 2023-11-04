namespace ExamPortalApp.Contracts.Data.Entities;

public partial class AttendanceRegister
{
    public string? TestName { get; set; }
    public string? ExamNo { get; set; }
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? IDNumber { get; set; }
    public int? Trial { get; set; }
    public int? StudentId { get; set; }
    public int? TestId { get; set; }
    public int? Absent { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Password { get; set; }

    public Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}