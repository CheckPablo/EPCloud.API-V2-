using System.ComponentModel.DataAnnotations;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public string AdminPwd { get; set; } = string.Empty;
        public int ImpersonatedCenterId { get; set; } 
    }
}
