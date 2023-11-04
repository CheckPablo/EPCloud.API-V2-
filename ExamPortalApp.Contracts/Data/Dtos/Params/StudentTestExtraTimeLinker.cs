namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentTestExtraTimeLinker
    {
        public int TestId { get; set; }
        public int[] StudentIds { get; set; } = new int[0];
    
        public string[] ExtraTimeIds { get; set; }
    }
}
