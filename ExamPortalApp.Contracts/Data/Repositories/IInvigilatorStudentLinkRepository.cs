using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IInvigilatorStudentLinkRepository : IRepositoryBase<InvigilatorStudentLink>
    {
        Task<bool> LinkStudentsAsync(InvigilatorStudentLinker linker);
    }
}