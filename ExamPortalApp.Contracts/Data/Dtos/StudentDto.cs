namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? ExamNo { get; set; }

        public string? IdNumber { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Removed { get; set; }

        public bool? Updated { get; set; }

        public bool? IsOnline { get; set; }

        public string PlainPassword { get; set; } = string.Empty;

        public Guid? Salt { get; set; }

        public string? StudentNo { get; set; }

        public string? EmailAddress { get; set; }

        public string? ContactNo { get; set; }

        public bool? SentConfirmation { get; set; }

        public int? CertLangId { get; set; }

        public int? CenterId { get; set; }

        public int? GradeId { get; set; }

        public int? RegionId { get; set; }

        public GradeDto? Grade { get; set; }
    }
}
