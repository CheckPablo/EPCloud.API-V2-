using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Center")]
        //public string SecurityQuestion { get; set; } = string.Empty;
        public int CenterId { get; set; }

        [Required]
        [Display(Name = "Role")]
        //public string SecurityQuestion { get; set; } = string.Empty;
        public short RoleId { get; set; }

        [Required]
        [Display(Name = "Contact Details")]
        public string ContactDetails { get; set; } = string.Empty;

        public string[] roles { get; set; } = new string[] { };

        [NotMapped]
        [Display(Name = "Number Of Candidates")]
        public int? NumberOfCandidates { get; set; }

    }
}
