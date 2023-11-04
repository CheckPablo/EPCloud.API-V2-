using System.ComponentModel.DataAnnotations;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class AdminLoginModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
 
        [Required]
        public int impersonatedCenterId { get; set;}
    }
}
