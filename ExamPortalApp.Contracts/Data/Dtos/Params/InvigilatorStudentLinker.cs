namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class InvigilatorStudentLinker
    {
        public int UserId { get; set; }
        public int[] StudentIds { get; set; } = new int[0];
    }
}
