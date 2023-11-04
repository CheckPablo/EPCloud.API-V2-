using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Answer
{
    public int Id { get; set; }

    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public string? OptionCode { get; set; }

    public string? AnswerDesc { get; set; }

    public virtual Question Question { get; set; } = null!;
}
