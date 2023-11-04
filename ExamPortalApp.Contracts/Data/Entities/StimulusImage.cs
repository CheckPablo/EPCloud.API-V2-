using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StimulusImage
{
    public int Id { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int ImageId { get; set; }

    public int StimulusId { get; set; }

    public virtual Image Image { get; set; } = null!;

    public virtual Stimulus Stimulus { get; set; } = null!;
}
