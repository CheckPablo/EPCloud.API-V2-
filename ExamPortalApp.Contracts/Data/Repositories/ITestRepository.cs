using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface ITestRepository : IRepositoryBase<Test>
    {
        Task<int> AddUpdateTestAsync(Test entity);
        Task<Test> UploadTestDocumentAsync(Test entity, IFormFile? file);
        Task<IEnumerable<StudentTestDTO>> GetStudentTestsBySectorCenterAndTestAsync(int? sectorId, int? centerId, int testId);
        Task<IEnumerable<Test>> SearchAsync(TestSearcher searcher);
        Task<IEnumerable<StudentTestDTO>> GetStudentTestsLinksAsync(int? sectorId, int? centerId, int testId);
        Task<IEnumerable<RandomOtp>> GetOTP(TestOTPSearcher searcher);
        Task<bool> CreateNewOTPAsync(TestOTPSearcher otpGenerator);
        Task<bool> SendOTPToStudentsAsync(int id);
        Task<(Test, string)> GetTestWithFileAsync(int testId);
        Task<(Test, string)> GetTestQuestionWithFileAsync(int testId);
        Task<(UploadedAnswerDocument, string)> GetTestWithAnswerDocAsync(int id);
        Task<bool> LinkStudentsAsync(StudentTestLinker linker);
        Task<bool> UploadSourceDocumentAsync(int testId, IFormFile file);
        Task<IEnumerable<UploadedSourceDocument>> GetUploadedSourceDocumentsAsync(int testId);
        Task<IEnumerable<UploadedAnswerDocument>> GetUploadedAnswerDocumentAsync(int testId);
        Task<int> DeleteAnswerDocumentAsync(int id);
        Task<int> DeleteSourceDocumentAsync(int id);
        Task<string> GetFileAsync(int id, string type);
        Task<bool> UploadAnswerDocumentAsync(int testId, IFormFile file);
        Task<string> GetWordFileAsync(int id);
        string ConvertWordDocToBase64Async(IFormFile file);
        Task<byte[]> GetAnswerFileAsync(int testId);
        Task<bool> CheckFileConvertedAsync(int id);
        byte[] ConvertAnswerDocumentAsync(IFormFile file);
        Task<Test> UploadTestWordDocumentAsync(Test entity, IFormFile file);
        Task<string> PreviewDocToUploadWord(Test entity, IFormFile file);
        Task<IEnumerable<Test>> GetOTPTestList(int? gradeId = null, int? subjectId = null);
        Task<byte[]> GetAudioFileAsync(int id);
        Task<IEnumerable<StudentTestList>> GetTestListAsync(int? studentId);
        Task<IEnumerable<StudentTestDTO>> SetTestStartDateTime(int? testId, int? studentId);
        Task<IEnumerable<RandomOtpDto>> ValidateTestOTP(int? testId, int? centerId, int? otp);
    }
}
