using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IInTestWriteRepository : IRepositoryBase<StudentTest>
    {
        Task ConvertWindowsTTS(WindowsSpeechModel winspeech);
        Task<bool> UploadStudentAnswerDocumentAsync(int testId, int studentId, IFormFile? file);
    }
}
