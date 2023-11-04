using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StudentRetriefe
{
    public int Id { get; set; }

    public byte[]? EncryptedText { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? StudentId { get; set; }

    public int? OldStudentId { get; set; }

    public virtual Student? Student { get; set; }
}
