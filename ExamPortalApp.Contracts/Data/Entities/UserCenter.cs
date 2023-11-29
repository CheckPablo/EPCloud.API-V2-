using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Entities;

public  class UserCenter 
{
    public int Id { get; set; }
    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Password { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? UserEmailAddress { get; set; }
    [NotMapped]
    public string? CenterName { get; set; }
    [NotMapped]
    public string? Description { get; set; }
    public string? ContactDetails { get; set; }

    public string? NumberOfCandidates { get; set; }

    public bool? VsoftApproved { get; set; }

    public bool? TermsAndConditions { get; set; }

    public DateTime? Modified { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSchoolAdmin { get; set; }

    public int? CenterTypeId { get; set; }

    public int CenterId { get; set; }

    public virtual Center? Center { get; set; } = null!;

    public virtual CenterType? CenterType { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
