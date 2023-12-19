﻿using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Infrastructure.Data.Repositories;
using Newtonsoft.Json;
using static SkiaSharp.HarfBuzz.SKShaper;
using SpeechLib;
using ExamPortalApp.Infrastructure.Extensions;
using System.IO;
using System.Linq.Expressions;
using ExamPortalApp.Infrastructure.Helpers;
using Syncfusion.Compression.Zip;
using static System.Net.Mime.MediaTypeNames;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InTestWriteController : CrudControllerBase<StudentTestDTO, StudentTest>
    {
        private readonly IInTestWriteRepository _inTestWriteRepository;
        private List<object> installedVoiceList = new List<object>();
         List<InstalledVoice> installedVoices = new List<InstalledVoice>();
        private string[] fileNames;

        //private IFormFileCollection scannedFiles;
        private readonly IHttpContextAccessor _contextAccessor;
        public InTestWriteController(IInTestWriteRepository inTestWriteRepository, IMapper mapper, IHttpContextAccessor contextAccessor) : base(mapper)
        {
            _inTestWriteRepository = inTestWriteRepository;
            _contextAccessor = contextAccessor;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<StudentTestDTO>> Delete(int id)
        {
            try
            {
                var response = await _inTestWriteRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<StudentTestDTO>>> Get()
        {
            try
            {
                var testSecurityLevels = await _inTestWriteRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<StudentTestDTO>>(testSecurityLevels);

                return Ok(testSecurityLevels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("installedVoices")]
        public List<object> InstalledVoices(int id)
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
               // var windowsVoices = synth.GetInstalledVoices().ToList();
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                   VoiceInfo? info = voice?.VoiceInfo ;
                    //synth.SelectVoice(voice.VoiceInfo.Name);
                    var voiceEntry = new { Name = info.Name, lang = info.Culture.Name,  }; 
                    installedVoiceList.Add(voiceEntry);
                    installedVoices.Add(voice); 
                }
                //string[] str = installedVoiceList.ToArray();
                //var windowsVoices = installedVoiceList;
                return installedVoiceList; 
               //Console.WriteLine(installedVoiceList); 
            }

        }

        /*[HttpGet("installedVoices")]
        public List<string> InstalledVoices(int id)
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    // VoiceInfo info = voice.VoiceInfo;
                    string fir = synth.SelectVoice(voice.VoiceInfo.Name).ToString();
                    installedVoiceList.Add(synth.SelectVoice(voice.VoiceInfo.Name));
                }
                //string[] str = installedVoiceList.ToArray();
                return installedVoiceList;
            }

        }*/

        [HttpGet("{id}")]
        public override async Task<ActionResult<StudentTestDTO>> Get(int id)
        {
            try
            {
                var testSecurityLevel = await _inTestWriteRepository.GetAsync(id);
                var result = _mapper.Map<StudentTestDTO>(testSecurityLevel);

                return Ok(testSecurityLevel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<StudentTestDTO>> Post(StudentTest StudentTest)
        {
            try
            {
                var response = await _inTestWriteRepository.AddAsync(StudentTest);
                var result = _mapper.Map<StudentTestDTO>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("upload-answer-document")]
        public async Task<ActionResult<StudentTestSave>> UploadAnswerDocumentAsync()
       //public async Task<ActionResult<StudentTestAnswers>> SaveAnswersInterval(StudentTestAnswerModel studentTestAnswers)
        {
           // System.Web.HttpPostedFile data = HttpContext.Current.Request.Files[0];
            try
            {
              var data = (Request.Form["data"]).ToString();
                var form = JsonConvert.DeserializeObject<StudentTestSave>(data);
                //if (Request.Form.Files.Count() > 0)

                if (form is not null)
                {
                    //var file = (Request.Form.Files.Count() > 0) && (Request.Form.Files[0] is not null) ? Request.Form.Files[0] : null;
                    var file = Request.Form.Files[0];
                    //var file = Request.Form.Files[0];
                    var response = await _inTestWriteRepository.UploadStudentAnswerDocumentAsync(form.TestId,form.StudentId, form.Accomodation ?? false, 
                        form.Offline ?? false, form.FullScreenClosed ?? false ,form.KeyPress ?? false, form.LeftExamArea ?? false, form.TimeRemaining, form.AnswerText, form.fileName, file);
                    //var result = _mapper.Map<TestDto>(response);
                    //return Ok(result);
                    return Ok();
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


        [HttpPost("save-irregular-keypressevent")]
        public async Task<ActionResult<KeyPressTracking>> SaveIrregularKeyPress(InvalidKeyPressEntries invalidKeyPressEntries)
        {
            try
            {
                var result = await _inTestWriteRepository.SaveIrregularKeyPress(invalidKeyPressEntries);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("scandocument")]
        public async Task<ActionResult<string>> ScanDocument(QrCodeModel qrcodeModel)
        {
            try
            {
                string testId = qrcodeModel.testId;
                string studentId = qrcodeModel.studentId;
                var QrCodeEntry =  testId + "" + studentId;
               //var chh = _contextAccessor.HttpContext?.Request.BaseUrl();
                var chh = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                //string baseUrl = string.Format("{ 0}://{1}{2}", Request.Scheme, Request.Host, Request.PathBase.Value.ToString());
                var badseUrl = Request.GetTypedHeaders().Referer.ToString() ?? "";
                return Ok(new { badseUrl }); 

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("add-scannedimages")]

        public async Task<ActionResult> UploadFiles(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var scannedFiles = Request.Form.Files;
            foreach (var formFile in scannedFiles)
            {
                if (formFile.Length > 0)
                {
                   
                        var folder = KnownFolderFinder.GetFolderFromKnownFolderGUID(new Guid("374DE290-123F-4565-9164-39C4925E467B"));
                        string tempFolderName = Guid.NewGuid().ToString();
                        //testEntity = await GetAsync(testId);
                        string root = folder + @"\" + tempFolderName.PadRight(5);
                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        
                        var filePath = Path.GetTempFileName();
                        string pathToSave = root;
                        //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        foreach (var file in scannedFiles)
                        {
                            //uploadResult = await file.CreateUpload(folderName, pathToSave);

                            using (var stream = new FileStream(pathToSave + ".jpeg", FileMode.Create, FileAccess.Write))
                            {
                                await file.CopyToAsync(stream);
                            }

                         fileNames = file.FileName.Split('.');
                      }

                    await _inTestWriteRepository.UploadScannedImagetoDB(fileNames,"","");

                    return Ok(new { count = files.Count, size });
                }

                // Process uploaded files
                // Don't rely on or trust the FileName property without validation.
            }
            return Ok(new { count = files.Count, size });
        }
        /*public async Task<ActionResult<bool>> UploadFiles()

        {
            var folder = "TestFolder";
            var folderName = Path.Combine("Uploads", folder);
            if (!(Directory.Exists(folderName)))
            {
                Directory.CreateDirectory(folderName);
            }
            try
            {
                string filename = "";
                filename = Guid.NewGuid().ToString() + ".jpeg";
                //return File(image, "image/jpeg");
                //_contextAccessor.HttpContext.Response.ContentType = "image/jpeg";
                //context.Response.ContentType = "text/plain";
                //_contextAccessor.HttpContext.Response.WriteAsync(filename); 
                //var scannedFiles = files;
                //var scannedFiles = Request.Form.Files;
                //var fileName = prefix + ContentDispositionHeaderValue.Parse(file.ContentDisposition)?.FileName?.Trim('"');
                folderName = Path.Combine("Uploads", folder);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                foreach (var file in scannedFiles)
                {
                    //uploadResult = await file.CreateUpload(folderName, pathToSave);

                    using (var stream = new FileStream(pathToSave, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                } 
            }
            catch(Exception ex){
                ex.Message.ToString(); ; 
            }
          //return (List<Upload>)scannedFiles;
          return true;
        }*/

       /*[HttpPost("[action]/{id}")]
       [DisableRequestSizeLimit]
       public async Task<ActionResult<List<Upload>>> UploadFiles([FromRoute] int id )
       {
           var files = Request.Form.Files;
           //files = new IFormCollection();

           if (files.Count < 1)
           {
               throw new Exception("No files provided for upload");
           }
           return await UploadExtensions.WriteFile(files, "", "")); 
;            //return  await _inTestWriteRepository.UploadScannedFiles(files); //, config.DirectoryBasePath, config.UrlBasePath, id);
       }*/

       /*[DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("{testId}/upload-answer-document")]
        public async Task<ActionResult> UploadScannedImagesAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var  folder ="";
            //var fileName = prefix + ContentDispositionHeaderValue.Parse(file.ContentDisposition)?.FileName?.Trim('"');
            var folderName = Path.Combine("Uploads", folder);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    FileStream stream;

                    string fullPath = Path.Combine(pathToSave, "fileName");
                    string dbPath = Path.Combine(folderName, "fileName");

                    using (stream = new FileStream(fullPath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }

                    /*using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }*/
        /*     }
         }

         // Process uploaded files
         // Don't rely on or trust the FileName property without validation.

         return Ok(new { count = files.Count, size });
     }*/

        //[HttpGet("windowstts/{selectedVoice}/{selectedText}")]
        // public async Task<ActionResult> WindowsTTS(string selectedVoice, string selectedText)
        [HttpPost("windowstts")]
        public async Task<ActionResult> WindowsTTS(WindowsSpeechModel? winspeech)
        {
            SpVoice voice = new SpVoice();
           
            try
            {
                //SpVoice voice = new SpVoice();
                using (SpeechSynthesizer synth = new SpeechSynthesizer{Volume = 50, Rate = 0})
                {

                    synth.SelectVoice(winspeech?.selectedVoice);
                    synth.Speak(winspeech?.selectedText);
                    //grpAdjustments.Enabled = false;
                    //synth.Speak(txtTextToSpeak.Text);
                    //grpAdjustments.Enabled = true;

                    //Console.WriteLine(installedVoices);
                }

                // var tts = await _inTestWriteRepository.ConvertWindowsTTS(winspeech);
                // var result = _mapper.Map<UserDto>(tts);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    

        [HttpPut("{id}")]
        public override Task<ActionResult<StudentTestDTO>> Put(int id, StudentTest entity)
        {
            throw new NotImplementedException();
        }
    }
}

