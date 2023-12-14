using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using ExamPortalApp.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class InTestWriteRepository : IInTestWriteRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;
        private string textToSave;
        private IEnumerable<StudentTestAnswers> resultToReturn;

        public InTestWriteRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentTest> AddAsync(StudentTest entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        /*
        public Task ConvertWindowsTTS(WindowsSpeechModel winspeech)
        {
            throw new NotImplementedException();
        }*/

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

        public async Task<bool> UploadStudentAnswerDocumentAsync(int testId,int studentId, bool accomodation, 
            bool offline, bool fullsScreenClosed, bool KeyPress, bool leftEamArea, string timeRemaining, string answerText, 
            string fileName,IFormFile file)
        {
           // the document is saving correctly with its text and formating
           // I want to extract text to put in the tracking table
            //var test = await GetAsync(testId);
            var fileExtension = Path.GetExtension(file.FileName);

            if (!string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Only Word Documents Supported");
            }
            //var base64 = 
            var fileBytes = file.ToByteArray();
            var base64BytConversion = fileBytes.ToBase64String();
            var convertedBytes = Convert.FromBase64String(base64BytConversion);

            using (MemoryStream stream = new MemoryStream(convertedBytes))
            {
                WordDocument document = new WordDocument();
                document.Open(stream, FormatType.Docx);
                 textToSave = document.GetText(); 
                 Console.WriteLine(textToSave);
                textToSave = textToSave.Replace("Created with a trial version of Syncfusion Word library or registered the wrong key in your application. Go to \"www.syncfusion.com/account/claim-license-key\" to obtain the valid key.", "");
            }
          

            var answerDocument = await _repository.GetFirstOrDefaultAsync<UserDocumentAnswer>(x => x.TestId == testId && x.StudentId == studentId);
            //if (testId == 0)

              var answerDocumentData = new UserDocumentAnswer()
                {
                    //DateModified = DateTime.Now,
                   
                    FileName = file.FileName,
                    TestId = testId,
                    StudentId = studentId,
                    TestDocument = fileBytes,
                };

            if (answerDocument != null)
            {
                
                answerDocumentData.Id = answerDocument.Id;
                await _repository.UpdateAsync(answerDocumentData, true);
            }
            else
            {
                if (answerDocumentData != null)
                {
                    Console.WriteLine(answerDocumentData);
                }
                await _repository.AddAsync(answerDocumentData, true);
            }

            var parameters = new Dictionary<string, object>();


             /*parameters.Add(StoredProcedures.Params.TestID, testId);
             parameters.Add(StoredProcedures.Params.StudentId, studentId);
             parameters.Add(StoredProcedures.Params.FileName, file.FileName);
             parameters.Add(StoredProcedures.Params.TestDocument, fileBytes);
            // parameters.Add(StoredProcedures.Params.CenterID, _user.CenterId);
             var result = _repository.ExecuteStoredProcAsync<UserCenter>(StoredProcedures.SaveStudentAnswer_TestUpload, parameters);*/
            await _repository.CompleteAsync();
            var trackingInfoToSave = new StudentTestAnswerModel(); 
            trackingInfoToSave.TestId = testId;
            trackingInfoToSave.StudentId = studentId;
            trackingInfoToSave.Accomodation = accomodation; 
            trackingInfoToSave.Offline = offline;
            trackingInfoToSave.FullScreenClosed = accomodation;
            trackingInfoToSave.KeyPress = accomodation;
            trackingInfoToSave.LeftExamArea = accomodation;
            trackingInfoToSave.TimeRemaining = timeRemaining;
            trackingInfoToSave.AnswerText = textToSave;
            trackingInfoToSave.FileName = file.FileName;
            // answerText ?: string | null;
           await SaveAnswersInterval(trackingInfoToSave); 
            return true;
        }

       /*public async Task<bool> UploadScannedImagesAsync(int testId, IFormFile file)
        {
            var test = await GetAsync(testId);
            var fileExtension = Path.GetExtension(file.FileName);

            if (!string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Only Word Documents Supported");
            }

            var fileBytes = file.ToByteArray();

            if (testId == 0)
            {
                var answerDocument = new UploadedAnswerDocument
                {
                    DateModified = DateTime.Now,
                    FileName = file.FileName,
                    TestId = test.Id,
                    TestDocument = fileBytes,
                };

                await _repository.AddAsync(answerDocument, true);
            }
            else
            {
                var uploadedAnswerDocs = await _repository.GetFirstOrDefaultAsync<UploadedAnswerDocument>(x => x.TestId == testId);
                //var uploadedAnswerDocs = await _repository.GetByIdAsync<UploadedAnswerDocument>(testId);
                var answerDocument = new UploadedAnswerDocument()
                {
                    TestId = testId,
                    FileName = file != null ? file.FileName : null,
                    TestDocument = fileBytes,
                    IsDeleted = false,
                };
                if (uploadedAnswerDocs != null)
                {
                    uploadedAnswerDocs.FileName = answerDocument.FileName;
                    uploadedAnswerDocs.TestDocument = answerDocument.TestDocument;
                }

                if (uploadedAnswerDocs?.TestDocument == null && file != null)
                {
                    await _repository.AddAsync(answerDocument, true);
                }
                if (uploadedAnswerDocs?.TestDocument != null && file != null)
                {
                    await _repository.UpdateAsync(uploadedAnswerDocs, true);

                }
            }

            return true;
        }*/

        public async Task<IEnumerable<StudentTestAnswers>> SaveAnswersInterval(StudentTestAnswerModel studentTestAnswersModel)
        {
             IEnumerable<StudentTestAnswers> result; 
            if (studentTestAnswersModel.AnswerText == null)
            {
                studentTestAnswersModel.AnswerText = "";
            }
            if (studentTestAnswersModel.AnswerText.Length == 0)
            {
                studentTestAnswersModel.AnswerText = "";
            }
            var parameters = new Dictionary<string, object>();
            //for (int x = 0; x < 1; x++) { 
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

            result = await _repository.ExecuteStoredProcAsync<StudentTestAnswers>(StoredProcedures.StudentTestAnswersIntervalSave, parameters);
            resultToReturn = result; 
            //}
            return resultToReturn;
        }

        public async Task<IEnumerable<KeyPressTracking>> SaveIrregularKeyPress(InvalidKeyPressEntries invalidKeyPressEntries)
        {

            var parameters = new Dictionary<string, object>();

            parameters.Add(StoredProcedures.Params.StudentId, invalidKeyPressEntries.StudentId);
            parameters.Add(StoredProcedures.Params.TestID, invalidKeyPressEntries.TestId);
            parameters.Add(StoredProcedures.Params.Event, invalidKeyPressEntries.Event);
            parameters.Add(StoredProcedures.Params.Reason, invalidKeyPressEntries.Reason);
       
            var result = await _repository.ExecuteStoredProcAsync<KeyPressTracking>(StoredProcedures.KeyPressTracking_ins, parameters);
            return result;
        }
        public async Task<Test> GetUserAnswerEntityAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<Test>(id);

            if (entity == null) throw new EntityNotFoundException<Test>(id);

            return entity;
        }
        public async Task<IEnumerable<UserDocumentAnswer>> GetUserAnswerDocumentAsync(int studentId, int testId) // there are one or many testId in this tabe so USE STUDENTID
        {
            return await _repository.GetWhereAsync<UserDocumentAnswer>(x => x.StudentId == studentId && x.TestId == testId);
        }

        

    
        /*Task<bool> IInTestWriteRepository.SaveIrregularKeyPress(InvalidKeyPressEntries invalidKeyPressEntries)
        {
            throw new NotImplementedException();
        }*/
    }
}
