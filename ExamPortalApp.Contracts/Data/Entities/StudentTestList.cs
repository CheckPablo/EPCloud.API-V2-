using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Entities;

public  class StudentTestList 
{
    public int Id { get; set; }
    public int? TestID { get; set; }
    public int? CenterID { get; set; }
    public int? TestCategoryID { get; set; }
    public int? TestSecurityLevel { get; set; }
    public string? TestName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExamDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ExamTime { get; set; }
    public DateTime? PaperExpiryDate { get; set; }
    public int? QuestionCount { get; set; }
    public int StudentID { get; set; }
    public bool Accomodation { get; set; }
    public bool Offline { get; set; }
    public string Upload { get; set; }
    public string Completed { get; set; }
    
    public bool? TermsAndConditions { get; set; }

    public DateTime? Modified { get; set; }

   // public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
