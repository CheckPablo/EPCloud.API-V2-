using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class BckaStimulusText
{
    public int StimulusTextId { get; set; }

    public int? StimulusId { get; set; }

    public string? StimulusText { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }
}
