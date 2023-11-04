using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class UserDocumentAnswersBackup : EntityBase
{
   // public int Id { get; set; }

    public string? FileName { get; set; }

    public byte[]? TestDocument { get; set; }

    public DateTime? TimeStamp { get; set; }

    public int? TestId { get; set; }

    public int? StudentId { get; set; }

    public int? OldStudentId { get; set; }

    public int? OldTestId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
