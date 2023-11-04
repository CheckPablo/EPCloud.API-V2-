namespace ExamPortalApp.Contracts.Data.Entities;

public partial class CenterAttendance
{
    public int? CenterID { get; set; }
    public int? NumberOfStudents { get; set; }
    public int? CenterTypeId { get; set; }
    public string? TestName { get; set; }
    public string? CenterName { get; set; }
    public string? Grade { get; set; }
    public string? TestCode { get; set; }
    public string? TestType { get; set; }
    public string? LearningArea { get; set;  }
    public DateTime? StartDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public virtual CenterType? CenterType { get; set; }

    public virtual ICollection<Grade> Sectors { get; } = new List<Grade>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();

    public virtual ICollection<User> Users { get; } = new List<User>();

}
