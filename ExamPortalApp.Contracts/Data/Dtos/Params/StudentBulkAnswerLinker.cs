namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentBulkAnswerLinker
    {
        public int[] StudentIds { get; set; } = new int[0];
        public int? TestId { get; set; }
    }
}
