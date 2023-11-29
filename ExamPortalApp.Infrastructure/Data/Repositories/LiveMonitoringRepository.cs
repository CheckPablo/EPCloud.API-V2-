
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class LiveMonitoringRepository : ILiveMonitoringRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;

        public LiveMonitoringRepository(IRepository repository, IOptions<ExamPortalSettings> options, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _user = accessor.GetLoggedInUser();
        }

        public async Task<List<LiveMonitoring>> GetLiveMonitoringCanidateList(int testId, int candidateSearchType, string name)
        {
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.TestID, testId  },
                { StoredProcedures.Params.InvigilatorId, _user.Id },
                { StoredProcedures.Params.Name, name },
                { StoredProcedures.Params.CenterID, _user.CenterId },
                { StoredProcedures.Params.CandidateSearchType, candidateSearchType },
            };

            var liveMonitoringCanidateList = await _repository.ExecuteStoredProcAsync<LiveMonitoring>(StoredProcedures.LiveMonitoringCanidateList, parameters).ConfigureAwait(false);

            return liveMonitoringCanidateList.ToList();
        }

        public async Task<List<KeyPressTracking>> GetLiveMonitoringIrregularities(int testId, int studentId)
        {
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.TestID, testId  },
                { StoredProcedures.Params.StudentId, studentId }
            };

            var keyPressTrackings = await _repository.ExecuteStoredProcAsync<KeyPressTracking>(StoredProcedures.LiveMonitoringIrregularities, parameters).ConfigureAwait(false);

            return keyPressTrackings.ToList();
        }
        public async Task<List<KeyPressTracking>> GetInvalidKeyPresses(int testId, int studentId)
        {
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.TestID, testId  },
                { StoredProcedures.Params.StudentId, studentId }
            };

            var keyPressTrackings = await _repository.ExecuteStoredProcAsync<KeyPressTracking>(StoredProcedures.LiveMonitoringKeypressTracking, parameters).ConfigureAwait(false);

            return keyPressTrackings.ToList();
        }

        public async Task<List<AnswerProgressTracking>> GetLiveMonitoringStudentAnswerProgress(int testId, int studentId)
        {
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.TestID, testId  },
                { StoredProcedures.Params.StudentId, studentId }
            };

            var answerProgressTrackings = await _repository.ExecuteStoredProcAsync<AnswerProgressTracking>(StoredProcedures.LiveMonitoringStudentAnswerProgress, parameters).ConfigureAwait(false);

            return answerProgressTrackings.ToList();
        }

        public async Task<bool> LinkStudentsExtraTimeAsync(StudentTestExtraTimeLinker linker)
        {
           ;
            for (int i  = 0; i < linker.StudentIds.Length; i++)
            {
                var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.StudentId, linker.StudentIds[i]},
                { StoredProcedures.Params.StudentExtraTime, linker.ExtraTimeIds[i] ?? "00:00:00"},
                { StoredProcedures.Params.ModifiedBy, _user.CenterId},
                { StoredProcedures.Params.TestID, linker.TestId},
            };

               await _repository.ExecuteStoredProcAsync<AttendanceRegister>(StoredProcedures.InsertExtraTimeMonitoring, parameters).ConfigureAwait(false);
                //await _repository.DeleteAsync<StudentTest>(link.Id);
            }
          

            return true;
        }
    }
}