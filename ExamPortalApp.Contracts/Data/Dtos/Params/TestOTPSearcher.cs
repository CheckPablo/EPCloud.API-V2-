namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class TestOTPSearcher
    {
        public int? CenterId  { get; set; }
        public int Code { get; set; }
        public int GradeId { get; set; }
        public int? SubjectId { get; set; }
        public int? TestId { get; set; }
        public DateTime? FromToDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Name { get; set; }
    }
}
