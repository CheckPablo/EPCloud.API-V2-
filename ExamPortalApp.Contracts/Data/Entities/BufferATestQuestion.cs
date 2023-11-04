using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class BufferATestQuestion
{
    public int TestQuestionId { get; set; }

    public int TestId { get; set; }

    public int QuestionId { get; set; }

    public int? QuestionNo { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }
}
