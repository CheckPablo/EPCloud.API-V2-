namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentTestLinker
    {
        public int TestId { get; set; }
        public int[] StudentIds { get; set; } = new int[0];
        public int[] AccomodationIds { get; set; } = new int[0];
        public int[] ReaderIds { get; set; } = new int[0];
        public Dictionary<int, string> ExtraTimeIds { get; set; }
    }
}
