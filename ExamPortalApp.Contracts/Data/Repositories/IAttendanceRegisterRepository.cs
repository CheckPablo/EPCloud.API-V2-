using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IAttendanceRegisterRepository
    {
        Task ResetTest(int studentId, int testId);
        Task<IEnumerable<AttendanceRegister>> SearchAsync(int? centerId, int? sectorId, int? subjectId, int? testId);
        Task SetStudentAbsentism(int studentId, int testId, int absent);
    }
}