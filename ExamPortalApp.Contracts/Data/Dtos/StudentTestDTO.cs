namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class StudentTestDTO
    {
        public int? StudentID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int? TestId { get; set; }
        public string ExamNo { get; set; }
        public string IDNumber { get; set; }
        public bool Linked { get; set; }
        public bool ElectronicReader { get; set; }
        public bool Accomodation { get; set; }
        public string StudentExtraTime { get; set; }
        public int? TestSecurityLevelId { get; set; }
        public string? LOGINUID { get; set; }
    }
}
