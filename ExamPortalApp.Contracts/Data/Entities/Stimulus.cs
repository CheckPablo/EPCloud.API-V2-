using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Stimulus
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public bool? HasImage { get; set; }

    public string? StimulusInstruction { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int SectorId { get; set; }

    public int? SectionId { get; set; }

    public int? StimulusTypeId { get; set; }

    public virtual ICollection<Question> Questions { get; } = new List<Question>();

    public virtual Grade Sector { get; set; } = null!;

    public virtual ICollection<StimulusImage> StimulusImages { get; } = new List<StimulusImage>();

    public virtual ICollection<StimulusMedium> StimulusMedia { get; } = new List<StimulusMedium>();

    public virtual ICollection<StimulusText> StimulusTexts { get; } = new List<StimulusText>();

    public virtual StimulusType? StimulusType { get; set; }
}
