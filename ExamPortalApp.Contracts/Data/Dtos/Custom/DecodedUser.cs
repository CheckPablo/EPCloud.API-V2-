namespace ExamPortalApp.Contracts.Data.Dtos.Custom
{
    public class DecodedUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int CenterId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
