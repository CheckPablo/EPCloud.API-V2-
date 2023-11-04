namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentTestSecurityDetails
    {
        public int? CenterId  { get; set; }
        public int GradeId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
    }
}
