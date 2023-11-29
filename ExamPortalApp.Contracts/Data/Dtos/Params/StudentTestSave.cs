namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentTestSave
    {
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public bool? Accomodation { get; set; }
        public bool? Offline {get;set;}
        public bool? FullScreenClosed { get; set; }
        public bool? KeyPress { get; set; }
        public bool? LeftExamArea { get; set; }
        public string? TimeRemaining { get; set;}
        public string? AnswerText { get; set; }
        public string? fileName { get; set; }
    }
}
