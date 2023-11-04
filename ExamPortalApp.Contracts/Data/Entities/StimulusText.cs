using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StimulusText
{
    public int Id { get; set; }

    public string? StimulusText1 { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int? StimulusId { get; set; }

    public virtual Stimulus? Stimulus { get; set; }
}
