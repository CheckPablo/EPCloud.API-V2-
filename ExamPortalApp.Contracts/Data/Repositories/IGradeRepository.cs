using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IGradeRepository : IRepositoryBase<Grade>
    {
        Task<IEnumerable<Grade>> GetAllByCenterIdAsync(int? id);
    }
}
