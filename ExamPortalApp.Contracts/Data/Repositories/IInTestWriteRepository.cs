using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IInTestWriteRepository : IRepositoryBase<StudentTest>
    {
        //Task ConvertWindowsTTS(WindowsSpeechModel winspeech);
        Task<bool> UploadStudentAnswerDocumentAsync(int testId, int studentId, bool accomodation, bool offline, bool fullScreenCLosed, bool kePress, bool leftExamArea, 
            string timeRemaining, string answerText, string fileName, IFormFile? file);
        Task<IEnumerable<KeyPressTracking>> SaveIrregularKeyPress(InvalidKeyPressEntries invalidKeyPressEntries);
        Task<IEnumerable<StudentTestAnswers>> SaveAnswersInterval(StudentTestAnswerModel studentTestAnswers);
        Task<int> UploadScannedImagetoDB(string[] fileNames, string testId, string studentId);
        Task<IEnumerable<ScannedImageOTPResult>> VerifyImagesOTP(ScannedImagesOTP scannedImagesOTP);
        //Task<Task<List<UploadedTest>>> UploadScannedFiles(IFormFileCollection files);
    }
}
