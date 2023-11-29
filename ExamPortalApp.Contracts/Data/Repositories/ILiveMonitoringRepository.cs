using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface ILiveMonitoringRepository
    {
        Task<List<LiveMonitoring>> GetLiveMonitoringCanidateList(int testId, int candidateSearchType, string name);
        Task<List<KeyPressTracking>> GetLiveMonitoringIrregularities(int testId, int studendId);
        Task<List<KeyPressTracking>> GetInvalidKeyPresses(int testId, int studendId);
        Task<List<AnswerProgressTracking>> GetLiveMonitoringStudentAnswerProgress(int testId, int studentId);
        Task<bool> LinkStudentsExtraTimeAsync(StudentTestExtraTimeLinker linker);

    }
}