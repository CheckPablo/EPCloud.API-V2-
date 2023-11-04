using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class InTestWriteRepository : IInTestWriteRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;
        public InTestWriteRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentTest> AddAsync(StudentTest entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public Task ConvertWindowsTTS(WindowsSpeechModel winspeech)
        {
            throw new NotImplementedException();
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

        public async Task<StudentTest> UpdateAsync(StudentTest entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }

        public async Task<bool> UploadStudentAnswerDocumentAsync(int testId,int studentId, IFormFile file)
        {
            //var test = await GetAsync(testId);
            var fileExtension = Path.GetExtension(file.FileName);

            if (!string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Only Word Documents Supported");
            }

            var fileBytes = file.ToByteArray();

            var parameters = new Dictionary<string, object>();


            parameters.Add(StoredProcedures.Params.TestID, testId);
            parameters.Add(StoredProcedures.Params.StudentId, studentId);
            parameters.Add(StoredProcedures.Params.FileName, file.FileName);
            parameters.Add(StoredProcedures.Params.TestDocument, fileBytes);
           // parameters.Add(StoredProcedures.Params.CenterID, _user.CenterId);
            var result = _repository.ExecuteStoredProcAsync<UserCenter>(StoredProcedures.SaveStudentAnswer_TestUpload, parameters);
        

            //byte[]? bytes = file.ToByteArray(); 
            //var answerDocument = new UploadedAnswerDocument
            //{
            //    DateModified = DateTime.Now,
            //    FileName = file.FileName,
            //    TestId = test.Id,
            //    TestDocument = fileBytes,
            //};

            //await _repository.AddAsync(answerDocument, true);

            return true;
        }

    }
}
