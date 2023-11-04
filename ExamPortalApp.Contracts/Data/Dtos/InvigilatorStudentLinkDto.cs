namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class InvigilatorStudentLinkDto
    {
        public int Id { get; set; }

        public DateTime? DateModifed { get; set; }

        public int? InvigilatorId { get; set; }

        public int? StudentId { get; set; }

        public int? OldStudentId { get; set; }

        public StudentDto? Student { get; set; }
    }
}
