using ExamPortalApp.Infrastructure.Constants;

namespace ExamPortalApp.Infrastructure.Exceptions
{
    public class NotActiveException : Exception
    {
        public NotActiveException() : base(ErrorMessages.Auth.NotActive)
        {
        }
    }

    public class NotApprovedException : Exception
    {
        public NotApprovedException() : base(ErrorMessages.Auth.NotApproved)
        {
        }
    }
}
