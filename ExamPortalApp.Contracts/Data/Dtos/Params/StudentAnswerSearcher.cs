namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentAnswerSearcher
    {
        public int? CenterId  { get; set; }
        public int GradeId { get; set; }
        public int? SubjectId { get; set; }
        public int? RegionId { get; set; }
        public int? TestId { get; set; }
        public string? Name { get; set; }
    }
}
