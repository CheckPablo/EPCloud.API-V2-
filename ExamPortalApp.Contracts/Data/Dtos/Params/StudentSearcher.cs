namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentSearcher
    {
        public int? CenterId  { get; set; }
        public int GradeId { get; set; }
        public int? SubjectId { get; set; }
        public string? Name { get; set; }
    }
}
