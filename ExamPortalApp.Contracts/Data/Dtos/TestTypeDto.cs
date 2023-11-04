using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Dtos;

public partial class TestTypeDto : EntityBase
{
    public string? Description { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }
}
