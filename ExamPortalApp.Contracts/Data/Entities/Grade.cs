using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Grade : EntityBase
{
    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public int? ModifiedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int? CenterId { get; set; }

    public virtual ICollection<BulkImportSectorSubject> BulkImportSectorSubjects { get; } = new List<BulkImportSectorSubject>();

    public virtual Center? Center { get; set; }

    public virtual ICollection<RandomOtp> RandomOtps { get; } = new List<RandomOtp>();

    public virtual ICollection<Stimulus> Stimuli { get; } = new List<Stimulus>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
