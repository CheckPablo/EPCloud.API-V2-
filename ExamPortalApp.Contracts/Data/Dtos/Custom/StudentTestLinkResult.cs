namespace ExamPortalApp.Contracts.Data.Dtos.Custom
{
    public class StudentTestLinkResult
    {
        public int StudentId { get; set; }
        public bool Linked { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ExamNo { get; set; }
        public string? IdNumber { get; set; }
    }
}
