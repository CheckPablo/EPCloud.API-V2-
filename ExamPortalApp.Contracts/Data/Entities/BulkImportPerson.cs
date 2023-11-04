using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class BulkImportPerson
{
    public int Id { get; set; }

    public int CenterNo { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public string StudentNo { get; set; } = null!;

    public string? Email { get; set; }

    public string? CellPhone { get; set; }

    public DateTime? ImportDate { get; set; }

    public bool? Imported { get; set; }

    public int? StudentId { get; set; }

    public int? CenterId { get; set; }

    public string? BatchId { get; set; }

    public int? RegionId { get; set; }

    public virtual ICollection<BulkImportSectorSubject> BulkImportSectorSubjects { get; } = new List<BulkImportSectorSubject>();

    public virtual Student? Student { get; set; }
}
