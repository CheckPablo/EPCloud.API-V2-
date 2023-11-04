namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Token { get; set; }
        public string? CenterName { get; set; }
        public int Role { get; set; }
        public int? ImpersonatedCenterId { get; set; }
        public string? adminPwd { get; set; }

    }
}
