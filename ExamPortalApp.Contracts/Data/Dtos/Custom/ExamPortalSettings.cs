namespace ExamPortalApp.Contracts.Data.Dtos.Custom
{
    public class ExamPortalSettings
    {
        public string Issuer { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string EncryptionKey { get; set; } = string.Empty;
        public EmailSettings? EmailSettings { get; set; } 
    }

    public class EmailSettings
    {
        public int Port { get; set; }
        public string Host { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
}
