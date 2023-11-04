namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class CenterAttendanceSearcher
    {
        public int? CenterId  { get; set; }
        public int SectorId { get; set; }
        public int? SubjectId { get; set; }
        public int? TestId { get; set; }
        public string? StartDate { get; set; }
        public string? EndExamDate { get; set; }
    }
}
