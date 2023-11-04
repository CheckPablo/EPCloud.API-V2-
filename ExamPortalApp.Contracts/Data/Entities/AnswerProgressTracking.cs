using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class AnswerProgressTracking
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public int? StudentId { get; set; }

    public string? AnswerText { get; set; }

    public int? AnswerCount { get; set; }

    public DateTime? DateModified { get; set; }
}
