using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Center : EntityBase
{
    public string? Name { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public string? Prefix { get; set; }

    public string? Disclaimer { get; set; }

    public int? CenterNo { get; set; }

    public string? AttendanceRegisterPassword { get; set; }

    public DateTime? ExpiryDate { get; set; }
    [NotMapped]
    public DateTime? LastUsedUpdate { get; set; }

    public int? MaximumLicense { get; set; }
    [NotMapped]
    public int? StudentsCount { get; set; }
    [NotMapped]
    public int? RegisteredTests { get; set; }
    [NotMapped]
    public int? StudentsCompleted { get; set; }
    [NotMapped]
    public int? StudentsLinked { get; set; }

    public int? ProvinceId { get; set; }

    public int? CenterTypeId { get; set; }

    public virtual CenterType? CenterType { get; set; }

    public virtual Province? Province { get; set; }

    public virtual ICollection<RandomOtp> RandomOtps { get; } = new List<RandomOtp>();

    public virtual ICollection<Grade> Sectors { get; } = new List<Grade>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
