using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StimulusMedium
{
    public int Id { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int MediaId { get; set; }

    public int StimulusId { get; set; }

    public virtual Medium Media { get; set; } = null!;

    public virtual Stimulus Stimulus { get; set; } = null!;
}
