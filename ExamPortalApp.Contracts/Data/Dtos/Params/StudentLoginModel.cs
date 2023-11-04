using System.ComponentModel.DataAnnotations;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class StudentLoginModel
    {
        [Required]
        public string StudentExamNo { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
