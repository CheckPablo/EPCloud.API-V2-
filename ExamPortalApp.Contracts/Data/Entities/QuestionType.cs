using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class QuestionType
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
