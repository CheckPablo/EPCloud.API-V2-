using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class TmpBckasn
{
    public int StudentProgressId { get; set; }

    public int StudentId { get; set; }

    public int TestId { get; set; }

    public string TestQuestionId { get; set; } = null!;

    public DateTime? TimeStamp { get; set; }

    public string? TimeRemaining { get; set; }

    public int AnswerId { get; set; }

    public int? HasMulti { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }
}
