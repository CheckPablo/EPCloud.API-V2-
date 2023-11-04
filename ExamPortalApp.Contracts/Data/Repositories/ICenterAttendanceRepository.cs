using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface ICenterAttendanceRepository
    {
        //Task<IEnumerable<CenterAttendance>> SearchAsync(int? centerId, int? sectorId, int? subjectId, int? testId);
        Task<IEnumerable<CenterAttendance>> SearchAsync(CenterAttendanceSearcher searcher);
    }
}