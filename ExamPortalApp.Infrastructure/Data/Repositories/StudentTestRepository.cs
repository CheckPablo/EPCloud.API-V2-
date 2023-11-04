using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Syncfusion.Pdf.Graphics;
using System.Web.Http.Results;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class StudentTestRepository : IStudentTestRepository
    {
        private readonly IRepository _repository;
        public StudentTestRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AcceptDisclaimer(int testId, int studentId, bool isDisclaimerAccepted)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add(StoredProcedures.Params.approve, testId);
            parameters.Add(StoredProcedures.Params.active, studentId);
            parameters.Add(StoredProcedures.Params.CenterID, isDisclaimerAccepted);
            var result = _repository.ExecuteStoredProcAsync<StudentTest>(StoredProcedures.AcceptDisclaimerInsert, parameters);
            if (result is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<StudentTest> AddAsync(StudentTest entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<StudentTest>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<StudentTest>> GetAllAsync()
        {
            return await _repository.GetAllAsync<StudentTest>();   
        }

        public async Task<StudentTest> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<StudentTest>(id);

            if (entity == null) throw new EntityNotFoundException<StudentTest>(id);

            return entity;
        }

        public async Task<IEnumerable<StudentTestAnswers>> SaveAnswersInterval(StudentTestAnswerModel studentTestAnswersModel)
       {

            var parameters = new Dictionary<string, object>();

            parameters.Add(StoredProcedures.Params.StudentId, studentTestAnswersModel.StudentId);
            parameters.Add(StoredProcedures.Params.TestID, studentTestAnswersModel.TestId);
            parameters.Add(StoredProcedures.Params.TimeRemaining, studentTestAnswersModel.TimeRemaining);
            parameters.Add(StoredProcedures.Params.KeyPress, studentTestAnswersModel.KeyPress);
            parameters.Add(StoredProcedures.Params.LeftExamArea, studentTestAnswersModel.LeftExamArea);
            parameters.Add(StoredProcedures.Params.Offline, studentTestAnswersModel.Offline);
            parameters.Add(StoredProcedures.Params.FullScreenClosed, studentTestAnswersModel.FullScreenClosed);
            parameters.Add(StoredProcedures.Params.FileName, studentTestAnswersModel.FileName);
            parameters.Add(StoredProcedures.Params.AnswerText, studentTestAnswersModel.AnswerText);
            parameters.Add(StoredProcedures.Params.Accomodation, studentTestAnswersModel.Accomodation);

            var result = await _repository.ExecuteStoredProcAsync<StudentTestAnswers>(StoredProcedures.StudentTestAnswersIntervalSave, parameters);
            return result;
        }


        public async Task<StudentTest> UpdateAsync(StudentTest entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }

        public Task<IEnumerable<StudentTestAnswers>> GetStudentTestDetails(int testId, int studentId)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add(StoredProcedures.Params.TestID, testId);
            parameters.Add(StoredProcedures.Params.StudentId, studentId);


            var result = _repository.ExecuteStoredProcAsync<StudentTestAnswers>(StoredProcedures.GetStudentTestDetails, parameters);
            return result;
        }
    }
}
