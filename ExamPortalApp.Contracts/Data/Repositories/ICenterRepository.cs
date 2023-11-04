using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface ICenterRepository : IRepositoryBase<Center>
    {
        Task<IEnumerable<Center>> GetCenterByUser();
        Task<IEnumerable<Center>> SearchCenterSummaryAsync();
    }
    //Task<IEnumerable<StudentTestDTO>> GetStudentTestsBySectorCenterAndTestAsync(int? sectorId, int? centerId, int testId);
}
