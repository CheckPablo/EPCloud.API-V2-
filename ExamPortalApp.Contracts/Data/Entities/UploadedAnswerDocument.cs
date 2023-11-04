using System.ComponentModel.DataAnnotations;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class UploadedAnswerDocument : EntityBase
{
    public int? TestId { get; set; }

    public string? FileName { get; set; }

    public byte[]? TestDocument { get; set; }

    public DateTime? DateModified { get; set; }

    [StringLength(200)]
    public string? FilePath { get; set; }

    public int? OldTestId { get; set; }
}
