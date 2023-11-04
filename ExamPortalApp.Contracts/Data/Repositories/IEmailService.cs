using ExamPortalApp.Contracts.Data.Dtos.Custom;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IEmailService
    {
        public void SendOrQueue(EmailDto input, bool isFromQueue = false);
    }
}
