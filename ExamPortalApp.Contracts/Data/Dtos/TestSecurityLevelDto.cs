using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Dtos;

public partial class TestSecurityLevelDto : EntityBase
{
    public string? Description { get; set; }

    public DateTime? DateModified { get; set; }
}
