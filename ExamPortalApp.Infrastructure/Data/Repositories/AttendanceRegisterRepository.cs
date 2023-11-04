using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using static SkiaSharp.HarfBuzz.SKShaper;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Options;
using ExamPortalApp.Infrastructure.Helpers;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class AttendanceRegisterRepository : IAttendanceRegisterRepository
    {
        private readonly IRepository _repository;
        private readonly ExamPortalSettings _examPortalSettings;
        private readonly DecodedUser? _user;



        public AttendanceRegisterRepository(IRepository repository, IOptions<ExamPortalSettings> options, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _examPortalSettings = options.Value;
            _user = accessor.GetLoggedInUser();
        }

        public async Task ResetTest(int studentId, int testId)
        {
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.StudentId, studentId },
                { StoredProcedures.Params.TestID, testId  },
            };

            await _repository.ExecuteStoredProcAsync<AttendanceRegister>(StoredProcedures.ResetTestForStudent, parameters).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AttendanceRegister>> SearchAsync(int? centerId, int? sectorId, int? subjectId, int? testId)
        {
            if (centerId == 0 || centerId == null)
            {
                centerId = _user.CenterId; 
            }
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.SectorId, sectorId },
                { StoredProcedures.Params.SubjectId, subjectId },
                { StoredProcedures.Params.TestID, testId  },
                { StoredProcedures.Params.CenterID, centerId }
            };
            var attendanceRegisters = await _repository.ExecuteStoredProcAsync<AttendanceRegister>(StoredProcedures.GetAttendanceRegister, parameters).ConfigureAwait(false);
            foreach (var attendanceRegister in attendanceRegisters)
            {
                attendanceRegister.Password = PasswordHelper.Decrypt(attendanceRegister.Password, _examPortalSettings.EncryptionKey);
            }

            return attendanceRegisters;

            //var result = await _repository.ExecuteStoredProcAsync<AttendanceRegister>(StoredProcedures.GetAttendanceRegister, parameters).ConfigureAwait(false);
            //return result;
        }

        public async Task SetStudentAbsentism(int studentId, int testId, int absent)
        {
            var parameters = new Dictionary<string, object>
            {
                { StoredProcedures.Params.StudentId, studentId },
                { StoredProcedures.Params.TestID, testId  },
                { StoredProcedures.Params.Absent, absent },
            };

            await _repository.ExecuteStoredProcAsync<AttendanceRegister>(StoredProcedures.SetAttendanceRegister, parameters).ConfigureAwait(false);
        }
    }
}