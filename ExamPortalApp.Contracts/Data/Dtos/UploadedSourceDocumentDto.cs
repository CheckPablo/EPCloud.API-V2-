using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class UploadedSourceDocumentDto : EntityBase
    {
        public int? TestId { get; set; }

        public string? FileName { get; set; }

        public byte[]? TestDocument { get; set; }

        public DateTime? DateModified { get; set; }

        public string? FilePath { get; set; }
    }
}
