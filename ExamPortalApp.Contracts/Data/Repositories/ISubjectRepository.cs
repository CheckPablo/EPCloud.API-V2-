using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface ISubjectRepository : IRepositoryBase<Subject>
    {
        Task<Subject> AddLinkToAllAsync(Subject subject);
        Task<Subject> UpdateLinkToAllAsync(Subject subject);
        Task<IEnumerable<Subject>> GetByGradeAsync(int id);
        Task<IEnumerable<Subject>> GetByStudentAsync(int id);
    }
}
