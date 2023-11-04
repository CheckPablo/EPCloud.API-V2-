using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Question
{
    public int Id { get; set; }

    public string? QuestionCode { get; set; }

    public string? QuestionStem { get; set; }

    public string? QuestionInstruction { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public string? NoteId { get; set; }

    public int? QuestionTypeId { get; set; }

    public int? StimulusId { get; set; }

    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();

    public virtual QuestionType? QuestionType { get; set; }

    public virtual Stimulus? Stimulus { get; set; }

    public virtual ICollection<TestQuestion> TestQuestions { get; } = new List<TestQuestion>();
}
