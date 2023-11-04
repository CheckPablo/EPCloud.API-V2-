using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class BulkImportSectorSubject
{
    public int Id { get; set; }

    public string SectorCode { get; set; } = null!;

    public string Sector { get; set; } = null!;

    public string SubjectCode { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string StudentNo { get; set; } = null!;

    public DateTime? ImportDate { get; set; }

    public bool? Imported { get; set; }

    public int? BulkImportId { get; set; }

    public int? SectorId { get; set; }

    public int? SubjectId { get; set; }

    public int? StudentSubjectId { get; set; }

    public string? BatchId { get; set; }

    public virtual BulkImportPerson? BulkImport { get; set; }

    public virtual Grade? SectorNavigation { get; set; }

    public virtual StudentSubject? StudentSubject { get; set; }

    public virtual Subject? SubjectNavigation { get; set; }
}
