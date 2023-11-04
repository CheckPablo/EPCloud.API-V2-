using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Image
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public byte[]? PhysicalFile { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public virtual ICollection<StimulusImage> StimulusImages { get; } = new List<StimulusImage>();
}
