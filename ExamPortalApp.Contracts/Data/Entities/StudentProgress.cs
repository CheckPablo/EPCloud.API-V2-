using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StudentProgress
{
    public int Id { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? TimeRemaining { get; set; }

    public int? HasMulti { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int StudentId { get; set; }

    public int TestId { get; set; }

    public int QuestionId { get; set; }

    public int AnswerId { get; set; }
}
