using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Medium
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public byte[]? PhysicalFile { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public virtual ICollection<StimulusMedium> StimulusMedia { get; } = new List<StimulusMedium>();
}
