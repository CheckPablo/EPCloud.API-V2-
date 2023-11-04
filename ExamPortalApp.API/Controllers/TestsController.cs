using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion;
using Syncfusion.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.EJ2.DocumentEditor;
using static SkiaSharp.HarfBuzz.SKShaper;
using FormatType = Syncfusion.EJ2.DocumentEditor.FormatType;
using WDocument = Syncfusion.DocIO.DLS.WordDocument;
using WFormatType = Syncfusion.DocIO.FormatType;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController : CrudControllerBase<TestDto, Test>
    {
        private readonly ITestRepository _testRepository;

        public TestsController(ITestRepository testRepository, IMapper mapper) : base(mapper)
        {
            _testRepository = testRepository;
        }

        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("convert-word-file")]
        public ActionResult<string> ConvertWordDoc()
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file is not null)
                {
                    var response = _testRepository.ConvertWordDocToBase64Async(file);

                    return Ok(response);
                }
                else
                {
                    return BadRequest("Data or file not provided");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<TestDto>> Delete(int id)
        {
            try
            {
                var response = await _testRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/answer-document")]
        public async Task<ActionResult> DeleteAnswerDocumentAsync(int id)
        {
            try
            {
                var response = await _testRepository.DeleteAnswerDocumentAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/source-document")]
        public async Task<ActionResult> DeleteSourceDocumentAsync(int id)
        {
            try
            {
                var response = await _testRepository.DeleteSourceDocumentAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<TestDto>>> Get()
        {
            try
            {
                var tests = await _testRepository.GetAllAsync();
                //var centerToDisplay = await _testRepository.GetByIdAsync<Test>(x => x.Id == _user.CenterId);
                var result = _mapper.Map<IEnumerable<TestDto>>(tests);

                return Ok(tests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("studenttestlist/{studentId}")]
        public async Task<ActionResult<StudentTestList[]>> studenttestlist(int? studentId)
        {
            try
            {
                var user = await _testRepository.GetTestListAsync(studentId);
                var result = _mapper.Map<IEnumerable<StudentTestList>>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getTestBySubject/{gradeId?}/{subjectId?}")]
        public async Task<ActionResult<IEnumerable<TestDto>>> GetByInvigilator(int? gradeId, int? subjectId)
        {
            try
            {
                var tests = await _testRepository.GetOTPTestList(gradeId, subjectId);
                var result = _mapper.Map<IEnumerable<TestDto>>(tests);

                return Ok(tests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<TestDto>> Get(int id)
        {
            try
            {
                var test = await _testRepository.GetAsync(id);
                var result = _mapper.Map<TestDto>(test);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{testId}/get-answer-file")]
        public async Task<string> GetAnswerFile(int testId)
        {
            try
            {
                var bytes = await _testRepository.GetAnswerFileAsync(testId);

                if (bytes.Length > 0)
                {
                    using (var stream = new MemoryStream(bytes))
                    {
                        stream.Position = 0;

                        //Hooks MetafileImageParsed event.
                        WordDocument.MetafileImageParsed += OnMetafileImageParsed;
                        WordDocument document = WordDocument.Load(stream, GetFormatType(".docx"));
                        //Unhooks MetafileImageParsed event.
                        WordDocument.MetafileImageParsed -= OnMetafileImageParsed;

                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
                        document.Dispose();
                        return json;
                    }
                }
                else return Newtonsoft.Json.JsonConvert.SerializeObject("");

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void OnMetafileImageParsed(object sender, MetafileImageParsedEventArgs args)
        {
            //You can write your own method definition for converting metafile to raster image using any third-party image converter.
            args.ImageStream = ConvertMetafileToRasterImage(args.MetafileStream);
        }

        private static Stream ConvertMetafileToRasterImage(Stream ImageStream)
        {
            //Here we are loading a default raster image as fallback.
            Stream imgStream = GetManifestResourceStream("ImageNotFound.jpg");
            return imgStream;
            //To do : Write your own logic for converting metafile to raster image using any third-party image converter(Syncfusion doesn't provide any image converter).
        }

        private static Stream GetManifestResourceStream(string fileName)
        {
            System.Reflection.Assembly execAssembly = typeof(WDocument).Assembly;
            string[] resourceNames = execAssembly.GetManifestResourceNames();
            foreach (string resourceName in resourceNames)
            {
                if (resourceName.EndsWith("." + fileName))
                {
                    fileName = resourceName;
                    break;
                }
            }
            return execAssembly.GetManifestResourceStream(fileName);
        }

        internal static FormatType GetFormatType(string format)
        {
            if (string.IsNullOrEmpty(format))
                throw new NotSupportedException("EJ2 DocumentEditor does not support this file format.");
            switch (format.ToLower())
            {
                case ".dotx":
                case ".docx":
                case ".docm":
                case ".dotm":
                    return FormatType.Docx;
                case ".dot":
                case ".doc":
                    return FormatType.Doc;
                case ".rtf":
                    return FormatType.Rtf;
                case ".txt":
                    return FormatType.Txt;
                case ".xml":
                    return FormatType.WordML;
                case ".html":
                    return FormatType.Html;
                default:
                    throw new NotSupportedException("EJ2 DocumentEditor does not support this file format.");
            }
        }
        [AllowAnonymous]
        [HttpGet("get-audio-file/{id}")]

        public async Task<ActionResult> GetAudioFile(int id)
        {
            try
            {
                var file = await _testRepository.GetAudioFileAsync(id);
                return File(file, "audio/mpeg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-file/{id}/{type}")]
        public async Task<ActionResult<string>> GetFile(int id, string type)
        {
            try
            {
                var file = await _testRepository.GetFileAsync(id, type);

                return Ok(new { file });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("student-list")]

        public async Task<ActionResult<StudentTestDTO>> GetStudentListAsync(int? sectorId, int? centerId, int testId)

        {
            try
            {
                //var test = await _testRepository.GetStudentTestsBySectorCenterAndTestAsync(sectorId, centerId, testId);
                var test = await _testRepository.GetStudentTestsLinksAsync(sectorId, centerId, testId);

                return Ok(test);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{testId}/get-answer-documents")]
        public async Task<ActionResult<UploadedAnswerDocumentDto>> GetUploadedAnswerDocument(int testId)
        {
            try
            {
                var docs = await _testRepository.GetUploadedAnswerDocumentAsync(testId);
                var result = _mapper.Map<IEnumerable<UploadedAnswerDocumentDto>>(docs);

                return Ok(docs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{testId}/get-converted-answerDoc")]
        public async Task<ActionResult<string>> GetAnswerDocPdfStream(int id)
        {
            bool checkDocExists = await _testRepository.CheckFileConvertedAsync(id);
            if (checkDocExists == true)
            {
                var (test, file) = await _testRepository.GetTestWithAnswerDocAsync(id);
                byte[] bytes = Convert.FromBase64String(file);
                var outputStream = new MemoryStream();
                Syncfusion.Pdf.PdfDocument pdfDocument = new Syncfusion.Pdf.PdfDocument();
                using (Stream stream = new MemoryStream(bytes))
                {
                    Syncfusion.DocIO.DLS.WordDocument doc = new Syncfusion.DocIO.DLS.WordDocument(stream, "docx");
                    DocIORenderer render = new DocIORenderer();
                    //Converts Word document into PDF document	
                    pdfDocument = render.ConvertToPDF(doc);
                    doc.Close();
                    pdfDocument.Save(outputStream);
                    outputStream.Position = 0;
                    byte[] byteArray = outputStream.ToArray();
                    pdfDocument.Close();
                    outputStream.Close();
                    string base64String = Convert.ToBase64String(byteArray);
                    return Content("data:application/pdf;base64," + base64String);
                }
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject("");
            }
        }

        [HttpGet("{testId}/get-converted-TestDoc")]
        public async Task<ActionResult<string>> GetTestDocPdfStream(int id)
        {
            var (test, file) = await _testRepository.GetTestWithAnswerDocAsync(id);
            byte[] bytes = Convert.FromBase64String(file);
            var outputStream = new MemoryStream();
            Syncfusion.Pdf.PdfDocument pdfDocument = new Syncfusion.Pdf.PdfDocument();
            using (Stream stream = new MemoryStream(bytes))
            {
                Syncfusion.DocIO.DLS.WordDocument doc = new Syncfusion.DocIO.DLS.WordDocument(stream, "docx");
                DocIORenderer render = new DocIORenderer();
                //Converts Word document into PDF document	
                pdfDocument = render.ConvertToPDF(doc);
                doc.Close();
                pdfDocument.Save(outputStream);
                outputStream.Position = 0;
                byte[] byteArray = outputStream.ToArray();
                pdfDocument.Close();
                outputStream.Close();
                string base64String = Convert.ToBase64String(byteArray);
                return Content("data:application/pdf;base64," + base64String);
            }
        }

        [HttpGet("{testId}/get-source-documents")]
        public async Task<ActionResult<TestDto>> GetUploadedSourceDocuments(int testId)
        {
            try
            {
                var docs = await _testRepository.GetUploadedSourceDocumentsAsync(testId);
                var result = _mapper.Map<IEnumerable<UploadedSourceDocumentDto>>(docs);

                return Ok(docs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-newOTP")]
        public async Task<ActionResult<bool>> NewTestOTP(TestOTPSearcher otpGenerator)
        {
            try
            {
                var result = await _testRepository.CreateNewOTPAsync(otpGenerator);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-test-with-file/{testId}")]
        public async Task<ActionResult<TestDto>> GetTestWithFile(int testId)
        {
            try
            {
                var (test, file) = await _testRepository.GetTestWithFileAsync(testId);
                var testDto = _mapper.Map<TestDto>(test);

                return Ok(new
                {
                    test = testDto,
                    file
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-questionpaper-file/{testId}")]
        public async Task<ActionResult<TestDto>> GetQuestionPaperFile(int testId)
        {
            try
            {
                var (test, file) = await _testRepository.GetTestQuestionWithFileAsync(testId);
                var testDto = _mapper.Map<TestDto>(test);

                return Ok(new
                {
                    test = testDto,
                    file
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     
        [HttpGet("get-word-file/{id}")]
        public async Task<string> ImportFileURL(int id)
        {
            try
            {
                return await _testRepository.GetWordFileAsync(id);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        [HttpPost("link-students")]
        public async Task<ActionResult> LinkStudents(StudentTestLinker linker)
        {
            try
            {
                var result = await _testRepository.LinkStudentsAsync(linker);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<TestDto>> Post(Test test)
        {
            try
            {
                var response = await _testRepository.AddUpdateTestAsync(test);
                // var result = _mapper.Map<TestDto>(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("add-test")]
        public async Task<ActionResult<Test>> PostDocumentAsync()
        {
            try
            {
                var data = (Request.Form["data"]).ToString();
                var form = JsonConvert.DeserializeObject<Test>(data);
                //if (Request.Form.Files.Count() > 0)

                if (form is not null)
                {
                    var file = (Request.Form.Files.Count() > 0) && (Request.Form.Files[0] is not null) ? Request.Form.Files[0] : null;
                    //var file = Request.Form.Files[0];
                     var response = await _testRepository.UploadTestDocumentAsync(form, file);
                        var result = _mapper.Map<TestDto>(response);
                    return Ok(result);
                }
             else
                {
                    return BadRequest("Data or file not provided");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("add-test-word")]
        public async Task<ActionResult<Test>> PostWordDocumentAsync(int testId)
        {
            try
            {
                var data = (Request.Form["data"]).ToString();
                var form = JsonConvert.DeserializeObject<Test>(data);
                var file = Request.Form.Files[0];

                //if(form is not null && file is not null)
                if (form is not null && file is not null)
                {
                    var response = await _testRepository.UploadTestWordDocumentAsync(form, file);
                    var result = _mapper.Map<TestDto>(response);

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Data or file not provided");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("preview-test-upload")]
        public async Task<ActionResult<string>> PreviewTestToUpload(int? testId)
        {
            try
            {
                var data = (Request.Form["data"]).ToString();
                var form = JsonConvert.DeserializeObject<Test>(data);
                var file = Request.Form.Files[0];

                //if(form is not null && file is not null)
                if (form is not null && file is not null)
                {
                    var response = await _testRepository.PreviewDocToUploadWord(form, file);
                    //var result = _mapper.Map<TestDto>(response);

                    return Ok( new { response });
                }
                else
                {
                    return BadRequest("Data or file not provided");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        [HttpPost("search-testsOTP")]
        public async Task<ActionResult> SearchTestsOTPAsync([FromQuery] TestOTPSearcher searcher)
        {
            try
            {
                var tests = await _testRepository.GetOTP(searcher);
                var result = _mapper.Map<IEnumerable<RandomOtpDto>>(tests);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("upload-word-file")]
        public async Task<ActionResult> UploadWordDoc()
        {
            try
            {
                var data = (Request.Form["data"]).ToString();
                var form = JsonConvert.DeserializeObject<Test>(data);
                var file = Request.Form.Files[0];

                if (form is not null && file is not null)
                {
                    var response = await _testRepository.UploadTestDocumentAsync(form, file);
                    var result = _mapper.Map<TestDto>(response);

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Data or file not provided");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("search-tests")]
        public async Task<ActionResult> SearchTestsAsync([FromQuery] TestSearcher searcher)
        {
            try
            {
                var tests = await _testRepository.SearchAsync(searcher);
                var result = _mapper.Map<IEnumerable<TestDto>>(tests);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/send-otp-toStudents")]
        public async Task<ActionResult<bool>> SendOTPToStudents(int id)
        {
            try
            {
                var result = await _testRepository.SendOTPToStudentsAsync(id);

                return Ok(result);
                //return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("setTestStartDate/{testId}/{studentId}")]
        public async Task<ActionResult<StudentTestDTO[]>> setTestStartDate(int? testId, int? studentId)
        {
            try
            {
                var result = await _testRepository.SetTestStartDateTime(testId, studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("{testId}/upload-answer-document")]
        public async Task<ActionResult<bool>> UploadAnswerDocumentAsync(int testId)
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file is not null && file.Length > 0)
                {
                    var response = await _testRepository.UploadAnswerDocumentAsync(testId, file);

                    return Ok(response);
                }
                else
                {
                    return BadRequest("Data or file not provided");
                }
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("{testId}/upload-source-document")]
        public async Task<ActionResult<bool>> UploadSourceDocumentAsync(int testId)
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file is not null && file.Length > 0)
                {
                    var response = await _testRepository.UploadSourceDocumentAsync(testId, file);

                    return Ok(response);
                }
                else
                {
                    return BadRequest("Data or file not provided");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet("validateTestOTP/{testId}/{centerId}/{otp}")]
        public async Task<ActionResult<RandomOtpDto[]>> validateOTP(int? testId, int? centerId, int otp)
        {
            try
            {

                var response = await _testRepository.ValidateTestOTP(testId, centerId, otp);
                var result = _mapper.Map<IEnumerable<RandomOtpDto>>(response);
                if (result.Count() == 0)
                {
                    return BadRequest("Invalid OTP");
                }
                else { 
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<TestDto>> Put(int id, Test entity)
        {
            throw new NotImplementedException();
        }
    }
}