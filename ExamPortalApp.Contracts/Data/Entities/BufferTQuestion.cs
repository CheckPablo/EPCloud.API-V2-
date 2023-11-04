using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class BufferTQuestion
{
    public int? QuestionId { get; set; }

    public int? QuestionTypeId { get; set; }

    public int? StimulusId { get; set; }

    public string? QuestionCode { get; set; }

    public string? QuestionStem { get; set; }

    public string? QuestionInstruction { get; set; }

    public string? NoteId { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }
}
