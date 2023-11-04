using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Dtos;

public partial class CenterDto 
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public string? Prefix { get; set; }

    public string? Disclaimer { get; set; }

    public int? CenterNo { get; set; }

    public string? AttendanceRegisterPassword { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? MaximumLicense { get; set; }

    public int? ProvinceId { get; set; }

    public int? CenterTypeId { get; set; }

    public string? LicenceInfo { get; set; }

    public CenterTypeDto? CenterType { get; set; }

    public ProvinceDto? Province { get; set; }
}
