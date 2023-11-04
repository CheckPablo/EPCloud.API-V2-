namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class UploadedAnswerDocumentDto
    {
        public int? TestId { get; set; }

        public string? FileName { get; set; }

        public byte[]? TestDocument { get; set; }

        public DateTime? DateModifed { get; set; }

        public string? FilePath { get; set; }
    }
}
