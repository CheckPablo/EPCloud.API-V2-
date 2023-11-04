using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Infrastructure.Constants;

namespace ExamPortalApp.Infrastructure.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : EntityBase
    {
        public EntityNotFoundException(int id)
            : base(string.Format(ErrorMessages.EntityNotFound, id, typeof(T)))
        {
        }
    }
}
