namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public string? SubjectGrade { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Removed { get; set; }

        public int SectorId { get; set; }
    }
}
