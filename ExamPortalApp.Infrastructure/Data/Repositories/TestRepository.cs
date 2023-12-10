using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Data;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using ExamPortalApp.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Collections;
using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;
using Aspose.Words;
using System;
using HarfBuzzSharp;
using SkiaSharp;
using System.IO.Pipes;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Interactive;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using static SkiaSharp.HarfBuzz.SKShaper;
//using Syncfusion.EJ2.DocumentEditor;
//using Syncfusion.EJ2.SpellChecker;
//using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using WDocument = Syncfusion.DocIO.DLS.WordDocument;
using WFormatType = Syncfusion.DocIO.FormatType;
using Syncfusion.Compression.Zip;
using System.IO.Compression;
using System.ComponentModel;
using Microsoft.WindowsAzure.Storage.Blob;
//using System.IO.Compression;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IRepository _repository;
        private readonly ExamPortalDatabaseContext _context;
        private readonly DecodedUser? _user;
        private readonly IMemoryCache _memoryCache; 
        private List<string> StudentListResult;
        private Stream? streamTemp;
        private byte[] WordFileBytes;
        private UserDocumentAnswer userDoc;
        private string startPath;
        private string zipFolderName;
        private string zipPath;
        private Test testEntity;
        private string root;
        private CloudBlobClient _blobClient;

        //private string base64;

        public TestRepository(IRepository repository, ExamPortalDatabaseContext context, IHttpContextAccessor accessor, IMemoryCache memoryCache)
        {
            _repository = repository;
            _context = context;
            _user = accessor.GetLoggedInUser();
            // = accesor.Id-f
            _memoryCache = memoryCache; 
        }

        public async Task<Test> AddAsync(Test entity)
        {
            try
            {
                var testExists = await _repository.AnyAsync<Test>(x => x.TestName == entity.TestName && x.SectorId == entity.SectorId);
                if (testExists)
                {
                    throw new Exception(ErrorMessages.TestEntryChecks.TestExists);
                }
                entity.CenterId = _user?.CenterId;

                var test = await _repository.AddAsync(entity, true);
                await TestOtpEntry(entity, entity.Id);
             
                return test;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<bool> TestOtpEntry(Test entity, int id)
        {
            var otpEntry = await _repository.GetFirstOrDefaultAsync<RandomOtp>(x => x.TestId == id); //THis line can be removed because at this point we are sure that there is no entry yet.	
            var OtpRecordAdd = new RandomOtp
            {
                TestId = id,
                SectorId = entity.SectorId,
                SubjectId = entity.SubjectId,
                CenterId = entity.CenterId ?? 0,
                Otp = 0,
                // OtpexpiryDate = dt1.AddHours(8),	
                DateModified = DateTime.UtcNow,
            };
            await _repository.AddAsync(OtpRecordAdd);
            await _repository.CompleteAsync();
            return true;
        }

        public async Task<int> AddUpdateTestAsync(Test entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    var testExists = await _repository.AnyAsync<Test>(x => x.TestName == entity.TestName && x.SectorId == entity.SectorId);
                    if (testExists)
                    {
                        throw new Exception(ErrorMessages.TestEntryChecks.TestExists);
                    }
                    var test = await AddAsync(entity);

                    return test.Id;
                }
                else
                {
                    var test = await UpdateAsync(entity);

                    return test.Id;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CheckFileConvertedAsync(int testId)
        {
            testId = 4383; 
            var checkAnswerDocEntry = await _repository.GetWhereAsync<UploadedAnswerDocument>(x => x.TestId == testId);
            if (checkAnswerDocEntry.Count() == 0 || checkAnswerDocEntry == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string ConvertWordDocToBase64Async(IFormFile file)
        {
            var fileBytes = file.ToByteArray();

            return fileBytes.ToBase64String();
        }


      
        public async Task<bool> CreateNewOTPAsync(TestOTPSearcher otpGenerator)
        {
            //if (question paper is missing){ Prompt user to upload a question paper}
            var testToCache = _memoryCache.Get(otpGenerator.TestId);
            if (testToCache == null)
            {
                testToCache = await GetTestToCache(otpGenerator.TestId);
                _memoryCache.Set(otpGenerator.TestId, testToCache, TimeSpan.FromMinutes(1440));
            }
            Console.WriteLine(testToCache.ToString());
            var parameters = new Dictionary<string, object>();
            otpGenerator.CenterId = _user?.CenterId;
            otpGenerator.Code = 0;
            parameters.Add(StoredProcedures.Params.Code, otpGenerator.Code);
            parameters.Add(StoredProcedures.Params.TestID, otpGenerator.TestId);
            parameters.Add(StoredProcedures.Params.CenterID, otpGenerator.CenterId);
            parameters.Add(StoredProcedures.Params.SectorId, otpGenerator.GradeId);
            parameters.Add(StoredProcedures.Params.SubjectId, otpGenerator.SubjectId);
            parameters.Add(StoredProcedures.Params.ModifiedDate, DateTime.UtcNow);

            var result = _repository.ExecuteStoredProcedure<RandomOtp>(StoredProcedures.NewOTPInsert, parameters);
            //if (result is not null && result[0] == StoredProcedures.Responses.OTPUpdated || result[0] == StoredProcedures.Responses.OTPSet)
            if (result is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            //var assessments = await _repository.GetWhereAsync<Assessment>(x => x.TestId == id);
            //var disclaimerAccepts = await _repository.GetWhereAsync<DisclaimerAccept>(x => x.TestId == id);
            //var irregularities = await _repository.GetWhereAsync<Irregularity>(x => x.TestId == id);
            //var keyPressTrackings = await _repository.GetWhereAsync<KeyPressTracking>(x => x.TestId == id);
            //var randomOtps = await _repository.GetWhereAsync<RandomOtp>(x => x.TestId == id);
            //var screenshots = await _repository.GetWhereAsync<Screenshot>(x => x.TestId == id);
            //var sourceDocs = await _repository.GetWhereAsync<TestQuestion>(x => x.TestId == id);
            //var sourceDocs = await _repository.GetWhereAsync<UserDocumentAnswer>(x => x.TestId == id);
            //var sourceDocs = await _repository.GetWhereAsync<UserScannedImage>(x => x.TestId == id);
            //var sourceDocs = await _repository.GetWhereAsync<UserDocumentAnswersBackup>(x => x.TestId == id);
            //var answerDocs = await _repository.GetWhereAsync<UploadedAnswerDocument>(x => x.TestId == id);
            //var studentTests = await _repository.GetWhereAsync<StudentTest>(x => x.TestId == id);
            //var logs = await _repository.GetWhereAsync<StudentTestLog>(x => x.TestId == id);

            //foreach (var doc in sourceDocs)
            //{
            //    await _repository.DeleteAsync<UploadedSourceDocument>(doc.Id);
            //}

            //foreach (var doc in answerDocs)
            //{
            //    await _repository.DeleteAsync<UploadedAnswerDocument>(doc.Id);
            //}

            //foreach (var log in logs)
            //{
            //    await _repository.DeleteAsync<StudentTestLog>(log.Id);
            //}

            //foreach (var tests in studentTests)
            //{
            //    await _repository.DeleteAsync<StudentTest>(tests.Id);
            //}

            await _repository.DeleteAsync<Test>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<int> DeleteAnswerDocumentAsync(int id)
        {
            await _repository.DeleteAsync<UploadedAnswerDocument>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<int> DeleteSourceDocumentAsync(int id)
        {
            await _repository.DeleteAsync<UploadedSourceDocument>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            //return await _repository.GetAllAsync<Test>();
            var tests = await _repository.GetWhereAsync<Test>(x => x.CenterId == _user.CenterId); //vsoft should be allowed to view all 
            return tests.OrderBy(x => x.TestName);
        }

        public async Task<IEnumerable<Test>> GetOTPTestList(int? gradeId = null, int? subjectId = null)
        {
            var tests = await _repository.GetWhereAsync<Test>(x => x.CenterId == _user.CenterId && x.SectorId == gradeId && x.SubjectId == subjectId); //vsoft should be allowed to view all 

            return tests.OrderBy(x => x.TestName);
        }

        public async Task<byte[]> GetAnswerFileAsync(int testId)
        {
            var docs = await GetUploadedAnswerDocumentAsync(testId);
            var doc = docs?.FirstOrDefault();

            if (doc?.TestDocument is null) //throw new Exception("No test document found");
            {
                try {
                    byte[] bytes;
                    bytes = new byte[0];
                    return bytes;
                }
                catch (Exception ex)
                { }
            }
            return doc.TestDocument;
        }

        public async Task<byte[]> GetUserAnswerFileAsync(int studentId, int testId)
        {
            var docs = await GetUserAnswerDocumentAsync(studentId, testId);
            var doc = docs?.FirstOrDefault();

            if (doc?.TestDocument is null) //throw new Exception("No test document found");
            {
                try
                {
                    byte[] bytes;
                    bytes = new byte[0];
                    return bytes;
                }
                catch (Exception ex)
                { }
            }
            return doc.TestDocument;
        }

      

        /*public  Task<byte[]> GetUserAnswerFile(int studentId, int testId)
        {
            var docs = await GetUserAnswerDocumentAsync(studentId, testId);
            var doc = docs?.FirstOrDefault();

            if (doc?.TestDocument is null) //throw new Exception("No test document found");
            {
                try
                {
                    byte[] bytes;
                    bytes = new byte[0];
                    return bytes;
                }
                catch (Exception ex)
                { }
            }
            return doc.TestDocument;
        }*/

        public async Task<Test> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<Test>(id);

            if (entity == null) throw new EntityNotFoundException<Test>(id);

            return entity;
        }

        public async Task<UserDocumentAnswer> GetUserAnswerDocAsync(int id, int studentId)
        {
            //var entity = await _repository.GetByIdAsync<UserDocumentAnswer>(id);
            var entity = await _repository.GetWhereAsync<UserDocumentAnswer>(x => x.TestId == id && x.StudentId == studentId );
           // var entity = entity.FirstOrDefault(); 

            //if (entity == null) throw new EntityNotFoundException<UserDocumentAnswer>(id);

            return entity.FirstOrDefault();

        }

        private async Task<IEnumerable<Grade>> GetTestGradeEntityAsync(int sectorId)
        {
            //var test = await GetAsync(testId);
            var gradeEntity = await _repository.GetWhereAsync<Grade>(x => x.Id == sectorId);

            return gradeEntity;
        }


        private async Task<IEnumerable<Student>> GetEligibleStudentsAsync(int testId)
        {
            var test = await GetAsync(testId);
            var students = await _repository.GetWhereAsync<Student>(x => x.CenterId == test.CenterId && x.GradeId == test.SectorId);

            return students;
        }

        public async Task<IEnumerable<Resulting>> SearchStudentAnswerAsync(int gradeId, int subjectId, int testId, int regionId)
        {

            var parameters = new Dictionary<string, object>();

            parameters.Add(StoredProcedures.Params.CenterID, _user.CenterId);
            parameters.Add(StoredProcedures.Params.SectorId, gradeId);
            parameters.Add(StoredProcedures.Params.SubjectId, subjectId);
            parameters.Add(StoredProcedures.Params.TestID, testId);
            parameters.Add(StoredProcedures.Params.RegionId, regionId);

            var result = await _repository.ExecuteStoredProcAsync<Resulting>(StoredProcedures.get_StudentAnswersList, parameters);
            return result;

        }


        public async Task<IEnumerable<RandomOtp>> GetOTP(TestOTPSearcher? searcher)
        {
            var query = _repository.GetQueryable<RandomOtp>();

            if (searcher?.TestId is not null) query = query.Where(x => x.TestId == searcher.TestId);

            var result = await query.Include(x => x.Test).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<UploadedAnswerDocument>> GetUploadedAnswerDocumentAsync(int testId)
        {
            
            return await _repository.GetWhereAsync<UploadedAnswerDocument>(x => x.TestId == testId);
        }

        public async Task<IEnumerable<UserDocumentAnswer>> GetUserAnswerDocumentAsync(int studentId, int testId) // there are one or many testId in this tabe so USE STUDENTID
        {
            return await _repository.GetWhereAsync<UserDocumentAnswer>(x => x.StudentId == studentId && x.TestId== testId);
        }

        public  Task<IEnumerable<UserDocumentAnswer>> GetUserAnswerDocument(int studentId, int testId) // there are one or many testId in this tabe so USE STUDENTID
        {
            return  _repository.GetWhereAsync<UserDocumentAnswer>(x => x.StudentId == studentId && x.TestId == testId);
        }

        public async Task<IEnumerable<UploadedSourceDocument>> GetUploadedSourceDocumentsAsync(int testId)
        {
            return await _repository.GetWhereAsync<UploadedSourceDocument>(x => x.TestId == testId);
        }

        public async Task<IEnumerable<StudentTestDTO>> GetStudentTestsBySectorCenterAndTestAsync(int? sectorId, int? centerId, int testId)
        {
            var test = await _repository.GetByIdAsync<Test>(testId, x => x.StudentTests);
            IEnumerable<Student> students; 
            if (test is null) return new List<StudentTestDTO>();
            if(test.CenterId is null)
            {
                test.CenterId = _user.CenterId; 
            }

             students = await _repository.GetWhereAsync<Student>(x => x.CenterId == test.CenterId && x.GradeId == test.SectorId);
             if (test is null) students = await _repository.GetWhereAsync<Student>(x => x.CenterId == _user.CenterId && x.GradeId == sectorId && x.IsDeleted == false);

            return students.Select(x => new StudentTestDTO
            {
                IDNumber = x.IdNumber,
                ExamNo = x.ExamNo,
                Linked = test.StudentTests.Any(y => y.StudentId == x.Id),
                Name = x.Name,
                StudentID = x.Id,
                Surname = x.Surname,
                StudentExtraTime = test.StudentTests.FirstOrDefault(y => y.StudentId == x.Id)?.StudentExtraTime ?? "00:00:00",
                Accomodation = test.StudentTests.FirstOrDefault(y => y.StudentId == x.Id)?.Accomodation ?? false,
                ElectronicReader = test.StudentTests.FirstOrDefault(y => y.StudentId == x.Id)?.ElectronicReader ?? false
            });
        }

        public async Task<IEnumerable<StudentTestDTO>> GetStudentTestsLinksAsync(int? sectorId, int? centerId, int testId)//method not being used yet
        {
          
            var parameters = new Dictionary<string, object>();
            //testId = 3402; 
            parameters.Add(StoredProcedures.Params.SectorId, sectorId);
            parameters.Add(StoredProcedures.Params.TestID, testId);
            parameters.Add(StoredProcedures.Params.CenterID, _user.CenterId);
            var result =  await _repository.ExecuteStoredProcedureAsync<StudentTestDTO>(StoredProcedures.StudentTestLinkGet, parameters).ConfigureAwait(false); ;
            //return result;
           return result;
        }
        
        public async Task LinkStudentsToTestAsync(int testId, int[] studentIds)  //method not being used yet
        {
            var currentLinks = await _repository.GetWhereAsync<StudentTest>(x => x.TestId == testId);

            foreach (var studentId in studentIds)
            {
                var studentTest = currentLinks.FirstOrDefault(x => x.TestId == studentId && x.StudentId == studentId);

                if (studentTest != null)
                {
                    currentLinks = currentLinks.Where(x => x.Id != studentTest.Id);
                }
                else
                {
                    studentTest = new StudentTest
                    {
                        //SubjectId = subjectId,
                        StudentId = studentId,
                        StudentExtraTime = studentTest.StudentExtraTime,
                    };

                    await _repository.AddAsync(studentTest);
                }
            }

            foreach (var studentTest in currentLinks)
            {
                await _repository.DeleteAsync<StudentSubject>(studentTest.Id);
            }

            await _repository.CompleteAsync();
        }

       /* public async Task<bool> studentAnswersBulkDownload(int studentId, int[] subjectIds)
        {
            //DeleteSubjectStudentLinks(studentId);
            var parameters = new Dictionary<string, object>();
            foreach (var subjectId in subjectIds)
            {
                parameters.Clear();
                parameters.Add(StoredProcedures.Params.StudentId, studentId);
                parameters.Add(StoredProcedures.Params.SubjectId, subjectId);

                linkResult = await _repository.ExecuteStoredProcAsync<StudentSubject>(StoredProcedures.LinkStudentSubjects, parameters);
            }
            if (linkResult is not null)
            {
                return true;
            }
            return false;
        }*/

        public async Task<bool> LinkStudentsTestAsync(StudentTestLinker linker) //method not being used yet
        {
            if (_user is null) return false;

            try
            {
                var linkedStudents = await _repository.GetWhereAsync<StudentTest>(x => x.TestId == linker.TestId &&
                    x.Student != null &&
                    x.Student.CenterId == _user.CenterId);

                foreach (var studentId in linker.StudentIds)
                {
                    var linkedStudent = linkedStudents.FirstOrDefault(x => x.StudentId == studentId);

                    if (linkedStudent is not null)
                    {
                        linkedStudents = linkedStudents.Where(x => x.StudentId != studentId).ToList();
                    }
                    else
                    {
                        var link = new StudentTest
                        {
                            ModifiedDate = DateTime.Now,
                            TestId = linkedStudent.TestId,
                            StudentId = studentId,
                            StudentExtraTime = linkedStudent.StudentExtraTime,
                            Accomodation = linkedStudent.Accomodation,
                            ElectronicReader = linkedStudent.ElectronicReader,


                        };

                        await _repository.AddAsync(link);
                    }
                }

                //foreach (var linkedStudent in linkedStudents)
                //{
                //    await _repository.DeleteAsync<InvigilatorStudentLink>(linkedStudent.Id);
                //}

                await _repository.CompleteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<(Test, string)> GetTestWithFileAsync(int testId)
        {
            var test = await GetAsync(testId);
            //var base64 = "";
            if (test is null) throw new InvalidOperationException();

            //var testToCache = _memoryCache.Get(testId);
            //if (testToCache == null)
            //{
            //    testToCache = await GetTestToCache(testId);
            //    _memoryCache.Set(testId, testToCache, TimeSpan.FromMinutes(1440));
            //    Console.WriteLine(testToCache.ToString());  
            //    return (test, testToCache.ToString());
            //}
            //Console.WriteLine(testToCache.ToString());
            var uploadTestEntry = await _repository.GetFirstOrDefaultAsync<UploadedTest>(x => x.Id == testId);

                var base64 = (uploadTestEntry?.TestDocument is not null) ? uploadTestEntry?.TestDocument.ToBase64String() : string.Empty;
            //}
           // _memoryCache.Set("employees", base64, TimeSpan.FromMinutes(1440));
         
            return (test, base64);
        }

        public async Task<(UserDocumentAnswer, string)> GetStudentFinalAnswerFileAsync(int testId, int studentId)
        {
            var test = await GetUserAnswerDocAsync(testId, studentId);
            if (test is null) throw new InvalidOperationException();
           
             var answerFileToDownLoad= await GetUserAnswerFileDownload(testId, studentId);
            
            Console.WriteLine(answerFileToDownLoad.ToString());
            return (test, answerFileToDownLoad.ToString());
        }

        /* public async Task<(UserDocumentAnswer, string)> studentAnswersBulkDownload(int testId, int[] studentIds)*/
        public async Task<List<string>> studentAnswersBulkDownload(int testId, int[] studentIds)
        {
            List<string> filesList = new ();
            foreach (var studentId in studentIds)
            {
                if (testId > 0)
                {
                    //var test = await GetUserAnswerDocAsync(testId, studentId);
                    var test = await GetUserAnswerFileDownloadBulk(testId, studentId);
                    if (test is null) throw new InvalidOperationException();
                   
                    filesList.Add(test); 
   
                }
            }
            return filesList;
        }

        public async Task<string> studentAnswersBulkDownloadString(int testId, int[] studentIds)
        {
            /*var test = await GetUserAnswerDocAsync(testId, studentId);
            var testEntity = await GetAsync(testId);
            var testGradeEntity = await GetTestGradeEntityAsync(testEntity.SectorId ?? 0);
            if (test is null) throw new InvalidOperationException();
            string tempFolderName = Guid.NewGuid().ToString();
            string root = @"C:\AnswersExport";
            //string root = @"C:\AnswersExport" + testEntity.TestName.PadRight(5) + "-" + testGradeEntity.First().Code.PadRight(5);
            //string root = @"C:\"+testEntity.TestName.PadRight(5)+"-"+ testGradeEntity.First().Code.PadRight(5);
            //string subdir =@"C:\AnswersExport\" +testEntity.TestName.PadRight(5) + "-" + testGradeEntity.First().Code.PadRight(5); 
            string subdir = @"C:\AnswersExport\" + tempFolderName;*/


            var folder = KnownFolderFinder.GetFolderFromKnownFolderGUID(new Guid("374DE290-123F-4565-9164-39C4925E467B"));
            string tempFolderName = Guid.NewGuid().ToString();
            testEntity = await GetAsync(testId);
             root = folder + @"\" + testEntity.TestName.PadRight(5);
            //string root = folder + @"\" + "AnswersExport".PadRight(5);
            string subdir = root + tempFolderName;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            foreach (var studentId in studentIds)
            {
                if (testId > 0)
                {
                   // var testEntity = await GetAsync(testId);
                    var test = await GetUserAnswerDocAsync(testId, studentId);
                    //var testEntity = await GetAsync(testId);
                    
                    var testGradeEntity = await GetTestGradeEntityAsync(testEntity.SectorId ?? 0); 
                    if (test is null) throw new InvalidOperationException();

                    Syncfusion.Compression.Zip.ZipArchive zipArchive = new Syncfusion.Compression.Zip.ZipArchive();
                    zipArchive.DefaultCompressionLevel = Syncfusion.Compression.CompressionLevel.Best;
                 
                    string path = root;
                    string fileName = "test";

                    var answerFileToDownLoad = await GetUserAnswerFileDownload(testId, studentId);
                    var fileNameDetails = await GetStudentFileNameDetails(testId, studentId);
                    var appendNo = GenerateRandomNo(); 
                    var blob = test.TestDocument;
                    using (Stream stream = new FileStream(subdir + "/" + testEntity.TestName.PadRight(5) + "-" + fileNameDetails.ExamNo.PadRight(5) + "-"+ fileNameDetails.Name + "-"+ fileNameDetails.Surname +"-"+ appendNo+ ".docx", FileMode.Create, FileAccess.Write))
                    {
                        stream.Write(blob, 0, blob.Length);
                        FileAttributes attributes = File.GetAttributes(subdir);
                        ZipArchiveItem item = new ZipArchiveItem(zipArchive, "SampleFile.cs", stream, true, (Syncfusion.Compression.FileAttributes)attributes);
                        zipArchive.AddItem(item);

                    }
                    //ZipFile.CreateFromDirectory(subdir, "destination.zip", CompressionLevel.Optimal, false);
                     startPath = subdir;

                     zipFolderName = "ExportedAnswers.zip".PadLeft(5);
                    
                    //string zipPath = startPath + "bulkStudentAnswerDownload.zip";

                     zipPath = startPath + zipFolderName;

                    //ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, false);
                    //ZipFile.ExtractToDirectory(zipPath, extractPath);
                    //turn root + "BulkAnswerDownload.zip";
                }

                else
                {
                    return @"C:\AnswersExport" + "BulkAnswerDownload.zip";
                    //return ("");
                }
            }
            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, false);
            var dir = new DirectoryInfo(root);
            var dirGuid = new DirectoryInfo(subdir);
            var zipDir = new DirectoryInfo(zipPath);
            dir.Delete(true);
            dirGuid.Delete(true);
            //zipDir.Delete(true); 


            return zipPath;
            //return File(stream, "application/octet-stream", zipPath);
            
            //return @"C:\AnswersExport" + "BulkAnswerDownload.zip";
            //return ("");
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public async Task<string> GetUserAnswerFileDownload(int testId, int studentId)
        {
            //studentId = 9476; 
            //testId = 4385; 
            var uploadTestEntry = await _repository.GetFirstOrDefaultAsync<UserDocumentAnswer>(x => x.Id == testId && x.StudentId == studentId);
            var base64 = (uploadTestEntry?.TestDocument is not null) ? uploadTestEntry?.TestDocument.ToBase64String() : string.Empty;
            return base64;
        }

        public async Task<string> GetUserAnswerFileDownloadBulk(int testId, int studentId)
        {
            //studentId = 9476; 
            //testId = 4385; 
            var uploadTestEntry = await _repository.GetFirstOrDefaultAsync<UserDocumentAnswer>(x => x.TestId == testId && x.StudentId == studentId);
            var base64 = (uploadTestEntry?.TestDocument is not null) ? uploadTestEntry?.TestDocument.ToBase64String() : string.Empty;
            return base64;
        }

        public async Task<Student> GetStudentFileNameDetails(int testId, int studentId)
        {
            //studentId = 9476; 
            //testId = 4385; 
            var studentEntry = await _repository.GetFirstOrDefaultAsync<Student>(x => x.Id == studentId);
            return studentEntry;
        }

        public async Task<(Test, string)> GetTestQuestionWithFileAsync(int testId)
        {
            var test = await GetAsync(testId);
            //var base64 = "";
            if (test is null) throw new InvalidOperationException();
            //var testToCache = _memoryCache.Get(testId);
            var testToCache = (_memoryCache.Get(testId) is not null) ? _memoryCache.Get(testId).ToString():string.Empty;
            //if (testToCache == null)
            //if ((testToCache.ToString() is null) ||testToCache.ToString() == "")
                if (testToCache.ToString().Length <= 0) { 
                //var base64 = (WordFileBytes is not null) ? WordFileBytes.ToBase64String() : string.Empty;
                //if (testToCache.ToString().IsNullOrEmpty())

                testToCache = await GetTestToCache(testId);
                //_memoryCache.Set(testId, testToCache, TimeSpan.FromMinutes(1440));
            }
            Console.WriteLine(testToCache.ToString());

            //var testToCache = _memoryCache.Get(testId);
            //if (testToCache == null)
            //{
            //    testToCache = await GetTestToCache(testId);
            //    _memoryCache.Set(testId, testToCache, TimeSpan.FromMinutes(1440));
            //    Console.WriteLine(testToCache.ToString());  
            //    return (test, testToCache.ToString());
            //}
            //Console.WriteLine(testToCache.ToString());
           // var uploadTestEntry = await _repository.GetFirstOrDefaultAsync<UploadedTest>(x => x.Id == testId);

           // var base64 = (uploadTestEntry?.TestDocument is not null) ? uploadTestEntry?.TestDocument.ToBase64String() : string.Empty;
            //}
            // _memoryCache.Set("employees", base64, TimeSpan.FromMinutes(1440));

            return (test, testToCache.ToString());
        }

        public async Task<string> GetTestToCache(int? testId)
        {
            var uploadTestEntry = await _repository.GetFirstOrDefaultAsync<UploadedTest>(x => x.Id == testId);
            var base64 = (uploadTestEntry?.TestDocument is not null) ? uploadTestEntry?.TestDocument.ToBase64String() : string.Empty;
            return base64;
        }


        /*public async Task<(UploadedAnswerDocument, string)> GetTestWithAnswerDocAsync(int testId)
        {
            var answerTemplate = await _repository.GetFirstOrDefaultAsync<UploadedAnswerDocument>(x => x.TestId == testId);
            string? base64 = ""; 
            //if (answerTemplate is null) throw new InvalidOperationException();
            if (answerTemplate == null)
            {
                //base64 = (answerTemplate.TestDocument is null) ? answerTemplate.TestDocument.ToBase64String() : null;
                base64 = (answerTemplate is null)  ? "" : string.Empty;
            }
            else
            { 
                base64 = (answerTemplate.TestDocument is not null) ? answerTemplate.TestDocument.ToBase64String() : string.Empty;
                //return (answerTemplate, base64);
            }

            return (answerTemplate, base64);
        }*/

        public async Task<(UploadedAnswerDocument, string)> GetTestWithAnswerDocAsync(int testId)
        {
            var answerTemplate = await _repository.GetFirstOrDefaultAsync<UploadedAnswerDocument>(x => x.TestId == testId);

            if (answerTemplate is null) //throw new InvalidOperationException();
                try { }
                catch (Exception ex)
                { }

            var base64 = (answerTemplate.TestDocument is not null) ? answerTemplate.TestDocument.ToBase64String() : string.Empty;

            return (answerTemplate, base64);
        }


        public async Task<Test> UpdateAsync(Test entity)
        {
            var testToUpdate = await _repository.GetByIdAsync<Test>(entity.Id);
            var testFileInfoToUpdate = await _repository.GetByIdAsync<UploadedTest>(entity.Id);
            if (testToUpdate != null)
            {
                testToUpdate.SectorId = entity.SectorId;
                testToUpdate.Code = entity.Code;
                testToUpdate.TestName = entity.TestName;
                testToUpdate.TestIntro = entity.TestIntro;
                testToUpdate.TestDuration = entity.TestDuration;
                testToUpdate.TestCreated = entity.TestCreated;
                testToUpdate.ExamDate = entity.ExamDate;
                testToUpdate.LanguageId = entity.LanguageId;
                testToUpdate.DateModified = entity.DateModified;
                testToUpdate.ModifiedBy = entity.ModifiedBy;
                testToUpdate.Tts = entity.Tts;
                testToUpdate.AnswerScanningAvailable = entity.AnswerScanningAvailable;
                testToUpdate.SubjectId = entity.SubjectId;
                testToUpdate.ExamId = entity.ExamId;
                testToUpdate.TestTypeId = entity.TestTypeId;
                testToUpdate.TestCategoryId = entity.TestCategoryId;
                //testToUpdate.TestDocument = entity.TestDocument;
                return await _repository.UpdateAsync(testToUpdate, true);

               /* var uploadedTests = new UploadedTest
                {
                    FileName = testFileInfoToUpdate.FileName,
                    TestDocument = testFileInfoToUpdate.TestDocument,
                    IsDeleted = false,
                };*/
            }
            else
            {
                throw new Exception($"Test {entity.TestName} not found.");
            }
        }

        public async Task<bool> UploadAnswerDocumentAsync(int testId, IFormFile file)
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
                if(uploadedAnswerDocs != null)
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
        }
        /* byte[] ITestRepository.ConvertAnswerDocumentAsync(IFormFile file)
         {
             throw new NotImplementedException();
         }*/
        public byte[] ConvertAnswerDocumentAsync(IFormFile file)
        {
            byte[] fileBytes;
            fileBytes = file.ConvertToPdf();
            fileBytes = file.ToByteArray();
            return fileBytes;
        }
        /*public async Task<byte[]> ConvertAnswerDocumentAsync(IFormFile file)
        {
            byte[] fileBytes;
            fileBytes = file.ConvertToPdf();
            fileBytes = file.ToByteArray();
            return fileBytes;
        }*/

        public async Task<bool> UploadSourceDocumentAsync(int testId, IFormFile file)
        {
            byte[] fileBytes;
            var test = await GetAsync(testId);
            var fileExtension = Path.GetExtension(file.FileName);
            var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), file.FileName);
            if (string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                fileBytes = file.ConvertToPdf();
            }
            else if (string.Equals(fileExtension, ".mp3", StringComparison.OrdinalIgnoreCase))
            {
                fileBytes = file.ToByteArray();

            }

            else
            {
                fileBytes = file.ToByteArray();
            }

            var sourceDocument = new UploadedSourceDocument
            {
                DateModified = DateTime.Now,
                FileName = file.FileName,
                TestId = test.Id,
                TestDocument = fileBytes,
            };

            await _repository.AddAsync(sourceDocument, true);

            return true;
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public async Task<Test> UploadTestDocumentAsync(Test entity, IFormFile? file)
        { 
            
            if (_user is null) throw new Exception("Not Authorised");
            byte[]? fileBytes = null;
            //fileBytes != null ? fileBytes : null,
            //bytes[].filebytes = file?.Toarray() ?? null
            string fileExtension;
            if (entity.CenterId == null)
            {
                entity.CenterId = _user.CenterId;
            }
           
            if (file != null)
            {

                fileExtension = Path.GetExtension(file.FileName);
            
                if (string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
                {
                    fileBytes = file.ConvertToPdf();
                }
                else
                {
                    fileBytes = file.ToByteArray();
                    //fileBytes = file.ToByteArray(".pdf");
                }
            }
            if (entity.Id == 0)
            {
                //var fileBytes = file.ToByteArray(".pdf");
                var randomOtp = new RandomOtp
                {
                    SectorId = entity.SectorId,
                    SubjectId = entity.SubjectId,
                    CenterId = _user.CenterId,
                    Otp = 0,
                    DateModified = DateTime.UtcNow,
                };

                //entity.TestDocument = fileBytes;
                //entity.FileName = file.FileName;
                entity.CenterId = _user.CenterId;
                entity.TestCreated = DateTime.Now;
                entity.RandomOtps.Add(randomOtp);

                var request = await _repository.AddAsync(entity, true);

                /*var uploadedTests = new UploadedTest()
                {
                    Id = entity.Id,
                    //FileName = file.FileName,
                    FileName = file != null ? file.FileName : null,
                    //TestDocument = fileBytes != null ? fileBytes : null,
                    TestDocument = fileBytes,
                    IsDeleted = false,
                };
                await _repository.AddAsync(uploadedTests, true);*/
                return request;
            }
            else
            {

                entity.CenterId = _user.CenterId;
                entity.TestCreated = DateTime.Now;
                var request = await _repository.UpdateAsync(entity, true);
                var uploadedTestDocs = await _repository.GetFirstOrDefaultAsync<UploadedTest>(x => x.Id == entity.Id);
                //var uploadedTestDocs = await _repository.GetFirstOrDefaultAsync<UploadedTest>(x => x.TestDocument != null && x.Id = entity.Id);
                var uploadedTests = new UploadedTest()
                {
                    Id = entity.Id,
                    FileName = file != null ? file.FileName: null,
                    //TestDocument = fileBytes != null ? fileBytes : null,
                    TestDocument = fileBytes,
                    IsDeleted = false,
                };
               /// if (uploadedTestDocs == null)
                if (uploadedTestDocs?.TestDocument == null && file != null)
                {
                    await _repository.AddAsync(uploadedTests, true);
                }
                 if (uploadedTestDocs?.TestDocument != null && file != null)
                {
                    await _repository.UpdateAsync(uploadedTests, true);
                }
               /* else
                {
                    return request;
                    //await _repository.UpdateAsync(uploadedTests, true);
                }*/
                return request;

            }
         
        }

        public async Task<Test> UploadTestWordDocumentAsync(Test entity, IFormFile file)
        {
            if (_user is null) throw new Exception("Not Authorised");
            //byte[] fileBytes;
            //var entity = await GetAsync(testId);

            //if (test is null) throw new InvalidOperationException();
            var fileExtension = Path.GetExtension(file.FileName);
            if (string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                WordFileBytes = file.ConvertToPdf();
                //WordFileBytes = ConvertAnswerDocumentAsync(file); 
            }

            //var fileBytes = file.ToByteArray(".pdf");
            if (entity.Id == 0)
            {
                var randomOtp = new RandomOtp
                {
                    SectorId = entity.SectorId,
                    SubjectId = entity.SubjectId,
                    CenterId = _user.CenterId,
                    Otp = 0,
                    DateModified = DateTime.UtcNow,
                };

                //entity.TestDocument = WordFileBytes;
                //entity.FileName = file.FileName;
                entity.CenterId = _user.CenterId;
                entity.TestCreated = DateTime.Now;
                entity.RandomOtps.Add(randomOtp);


                var request = await _repository.AddAsync(entity, true);
                var uploadedTests = new UploadedTest()
                {
                    Id = entity.Id,
                    FileName = file.FileName,
                    TestDocument = WordFileBytes,
                    IsDeleted = false,
                };
                await _repository.AddAsync(uploadedTests, true);
                return request;
            }
            else
            {
                var request = await _repository.UpdateAsync(entity, true);

                var uploadedTestDocs = await _repository.GetWhereAsync<UploadedTest>(x => x.Id == entity.Id);
                var uploadedTests = new UploadedTest()
                {
                    Id = entity.Id,
                    FileName = file.FileName,
                    TestDocument = WordFileBytes,
                    IsDeleted = false,
                };
                if (uploadedTestDocs == null)
                {
                    await _repository.AddAsync(uploadedTests, true);
                }
                else 
                {
                    await _repository.UpdateAsync(uploadedTests, true);
                }
                return request;

            }
        }

        public async Task<IEnumerable<Test>> SearchAsync(TestSearcher? searcher)
        {
            if (_user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

            var query = _repository.GetQueryable<Test>()
                .Include(s => s.Sector)
                .Include(s => s.Subject)
                .Include(s => s.TestType)
                .Where(x => x.CenterId == _user.CenterId);//Remember to add clause to allow VSOFT to view from all centers/schools

            if (searcher?.GradeId is not null) query = query.Where(x => x.SectorId == searcher.GradeId);
            //if (searcher?.SubjectId is not null) query = query.Where(s => s.Subjects.Any(ss => ss.SubjectId == searcher.SubjectId));
            if (searcher?.SubjectId is not null) query = query.Where(s => s.SubjectId == searcher.SubjectId);

            if (searcher.FromDate.HasValue)
            {
                query = query.Where(x => x.ExamDate >= searcher.FromDate && (!searcher.EndDate.HasValue || x.ExamDate <= searcher.EndDate));
            }

            var data = await query.ToListAsync();

            var result = data.Select(x => new Test
            {
                Id = x.Id,
                Code = x.Code,
                TestName = x.TestName,
                TestType = x.TestType,
                ExamDate = x.ExamDate,
                TestCreated = x.TestCreated,
                Sector = new Grade
                {
                    Id = x.SectorId ?? 0,
                    Code = x.Sector.Code
                },
                Subject = new Subject
                {
                    Description = x.Subject.Description,
                },
                TestTypeId = x.TestTypeId,
            });

            return result;
        }
        public Task<IEnumerable<StudentTestDTO>> SetTestStartDateTime(int? testId, int? studentId)
        {
            var parameters = new Dictionary<string, object>();
        
            parameters.Add(StoredProcedures.Params.TestID, testId);
            parameters.Add(StoredProcedures.Params.StudentId, studentId);

            var result = _repository.ExecuteStoredProcAsync<StudentTestDTO>(StoredProcedures.updateTestStartDateTime, parameters);
            return result;
        }

        public async Task<bool> SendOTPToStudentsAsync(int id)
        {
            var otpEntry = await _repository.GetFirstOrDefaultAsync<RandomOtp>(x => x.TestId == id, x => x.Test);

            if (otpEntry == null) { return false; }

            var students = await _repository.GetWhereAsync<Student>(x => x.StudentTests.Any(y => y.TestId == id));

            foreach (var student in students) //a null check is needed here 
            {
                await SendOTPToStudentAsync(student, otpEntry);
            }

            return true;
        }

        private async Task SendOTPToStudentAsync(Student student, RandomOtp otpEntry)
        {
            var test = otpEntry.Test;
            var email = student.EmailAddress;
            SendApprovalEmailAsync(email, test.TestName, otpEntry.Otp);
        }

        private async Task SendApprovalEmailAsync(string addressToMail, string testName, int otp)
        {
            //if (user.UserEmailAddress is null) return;

            #region Mail Message
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("qiscmapp@gmail.com");
            mail.To.Add(addressToMail);
            mail.Bcc.Add("Tinashe@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = "Exam Portal Cloud: " + testName + " One Time Pin";
            mail.Body = "Dear User: \n \n"
            + " Your One Time Pin for the " + testName + " exam is " + otp + " \n \n"
            + " PLEASE READ BELOW VERY CAREFULLY: \n \n"
            + " For best results please ensure one of the following Browsers are installed: \n \n"
            + " • Google Chrome \n"
            + " • Firefox \n"
            + " • Safari \n \n"
            + " Exam Portal Cloud is not compatible with Internet Explorer. \n \n"
            + " It is strongly recommended that Exam Portal Cloud is used on a desktop or a laptop. Tablets and phones may prove challenging to use with this paper. Using Tablets and phones is at your own discretion. \n \n"
            + " Safe Exam is not required for tablets (Apple and Android). IT IS NOT RECOMMENDED THAT YOU COMPLETE THIS TEST ON A TABLET OR ON YOUR PHONE. \n \n"
            + " Students to use Exam Portal Cloud, will need to download Safe Exam Browser from the following link https://sourceforge.net/projects/seb/files/seb/SEB_2.4.1/SafeExamBrowserInstaller.exe/download Please refer to the student guide emailed by your invigilator. Once they have Safe Exam Browser installed on their computers, the student section will open within Safe Exam Browser after they click the “Student Login” link. \n \n"

            + " Kind Regards, \n"
            + " The Exam Portal Cloud team";
            #endregion

            #region Smtp Client
            SmtpClient smtpServer = new SmtpClient();

            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");
            smtpServer.Timeout = 20000;
            #endregion

            try
            {
                await smtpServer.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SendApprovalEmailAsync(int id, string addressToMail, string testName, int otp)
        {
            //if (user.UserEmailAddress is null) return;

            #region Mail Message
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("qiscmapp@gmail.com");
            mail.To.Add(addressToMail);
            mail.Bcc.Add("Tinashe@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = "Exam Portal Cloud: " + testName + " One Time Pin";
            mail.Body = "Dear User: \n \n"
            + " Your One Time Pin for the " + testName + " exam is " + otp + " \n \n"
            + " PLEASE READ BELOW VERY CAREFULLY: \n \n"
            + " For best results please ensure one of the following Browsers are installed: \n \n"
            + " • Google Chrome \n"
            + " • Firefox \n"
            + " • Safari \n \n"
            + " Exam Portal Cloud is not compatible with Internet Explorer. \n \n"
            + " It is strongly recommended that Exam Portal Cloud is used on a desktop or a laptop. Tablets and phones may prove challenging to use with this paper. Using Tablets and phones is at your own discretion. \n \n"
            + " Safe Exam is not required for tablets (Apple and Android). IT IS NOT RECOMMENDED THAT YOU COMPLETE THIS TEST ON A TABLET OR ON YOUR PHONE. \n \n"
            + " Students to use Exam Portal Cloud, will need to download Safe Exam Browser from the following link https://sourceforge.net/projects/seb/files/seb/SEB_2.4.1/SafeExamBrowserInstaller.exe/download Please refer to the student guide emailed by your invigilator. Once they have Safe Exam Browser installed on their computers, the student section will open within Safe Exam Browser after they click the “Student Login” link. \n \n"

            + " Kind Regards, \n"
            + " The Exam Portal Cloud team";
            #endregion

            #region Smtp Client
            SmtpClient smtpServer = new SmtpClient();

            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");
            smtpServer.Timeout = 20000;
            #endregion

            try
            {
                await smtpServer.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<bool> LinkStudentsAsync(StudentTestLinker linker)
        {
            var test = await _repository.GetByIdAsync<Test>(linker.TestId, x => x.StudentTests);

            #region Validation
            if (test is null) return false;
            #endregion

            var currentLinks = await _repository.GetWhereAsync<StudentTest>(x => x.TestId == linker.TestId);

            foreach (var link in currentLinks)
            {
                await _repository.DeleteAsync<StudentTest>(link.Id);
            }

            await _repository.CompleteAsync();

            foreach (var id in linker.StudentIds)
            {
                linker.ExtraTimeIds.TryGetValue(id, out var extraTime);

                var studentTest = new StudentTest
                {
                    StudentId = id,
                    TestId = linker.TestId,
                    Absent = false,
                    Accomodation = linker.AccomodationIds.Any(x => x == id),
                    ElectronicReader = linker.ReaderIds.Any(x => x == id),
                    ModifiedBy = _user?.Id,
                    ModifiedDate = DateTime.Now,
                    StudentExtraTime = extraTime
                };

                await _repository.AddAsync(studentTest);
            }

            await _repository.CompleteAsync();

            return true;
        }

        public async Task<string> PreviewDocToUploadWord(Test entity, IFormFile file)
        {
            if (_user is null) throw new Exception("Not Authorised");
            //byte[] fileBytes;
            //var entity = await GetAsync(testId);
            var test = await GetAsync(entity.Id);
            if (test is null) throw new InvalidOperationException();
            var fileExtension = Path.GetExtension(file.FileName);
            if (string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                WordFileBytes = file.ConvertToPdf();
                //WordFileBytes = ConvertAnswerDocumentAsync(file); 
            }

            var base64 = (WordFileBytes is not null) ? WordFileBytes.ToBase64String() : string.Empty;

            return base64;
            //return (test, base64);
        }


        public async Task<string> GetFileAsync(int id, string type)
        {
            if (type == "source")
            {
                var doc = await _repository.GetByIdAsync<UploadedSourceDocument>(id);

                if (doc?.TestDocument == null) return string.Empty;

                var base64 = doc.TestDocument.ToBase64String();

                return base64;
            }
            else if(type == "mp3")
            {

                var doc = await _repository.GetByIdAsync<UploadedSourceDocument>(id);

                if (doc?.TestDocument == null) return string.Empty;

                var base64 = doc.TestDocument.ToBase64String();

                return "data:audio/ogg;base64," + base64;
            }
            else
            {
                var doc = await _repository.GetByIdAsync<UploadedAnswerDocument>(id);

                if (doc?.TestDocument == null) return string.Empty;

                var base64 = doc.TestDocument.ToBase64String();

                return base64;
            }
        }
        public async Task<IEnumerable<StudentTestList>> GetTestListAsync(int? id)
        {

            var parameters = new Dictionary<string, object>();
            parameters.Add(StoredProcedures.Params.id, id);
            //parameters.Add(StoredProcedures.Params.CenterID, _user.CenterId);      //make sure that students are from that center only, adjust SP
            var result = _repository.ExecuteStoredProcAsync<StudentTestList>(StoredProcedures.StudentTestList, parameters);
            return result.Result;

        }
        public async Task<byte[]> GetAudioFileAsync(int id)
        {
            {
                var doc = await _repository.GetByIdAsync<UploadedSourceDocument>(id);

                if (doc?.TestDocument == null) return new byte[0];
             
                var audioByteArray = doc.TestDocument;

                return audioByteArray;
            }
        }
        public async Task<string> GetWordFileAsync(int id)
        {
            var base64string = await GetFileAsync(id, "source");
            var bytes = Convert.FromBase64String(base64string);

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                WordDocument document = new WordDocument();
                document.Open(stream, FormatType.Docx);
                string json = JsonConvert.SerializeObject(document,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                document.Dispose();
                stream.Dispose();
                return json;
            }
        }

        public async Task<IEnumerable<RandomOtpDto>> ValidateTestOTP(int? testId, int? centerId, int? otp)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add(StoredProcedures.Params.TestID, testId);
            parameters.Add(StoredProcedures.Params.CenterID, centerId);
            parameters.Add(StoredProcedures.Params.OTP, otp);

            var result = await _repository.ExecuteStoredProcAsync<RandomOtpDto>(StoredProcedures.Get_ConfirmTestOTPExist, parameters);

            return result;
        }

        
    }
}
