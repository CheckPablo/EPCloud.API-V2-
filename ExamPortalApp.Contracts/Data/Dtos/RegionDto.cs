namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class RegionDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int? CenterId { get; set; }

        public CenterDto? Center { get; set; }
    }
}
