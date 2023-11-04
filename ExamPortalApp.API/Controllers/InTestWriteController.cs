using AutoMapper;
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
        public InTestWriteController(IInTestWriteRepository inTestWriteRepository, IMapper mapper) : base(mapper)
        {
            _inTestWriteRepository = inTestWriteRepository;
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
        /*[HttpPost("{testId}/{studentId}upload-answer-document")]*/
        [HttpPost("upload-answer-document")]
        /*[HttpPost]
        public override async Task<ActionResult<TestDto>> Post(Test test)*/
        //public async Task<ActionResult<bool>> UploadAnswerDocumentAsync(StudentTestSave studentTestSave)
                public async Task<ActionResult<StudentTestSave>> UploadAnswerDocumentAsync()
        {
           // System.Web.HttpPostedFile data = HttpContext.Current.Request.Files[0];
            try
            {
              var data = (Request.Form["data"]).ToString();
                var form = JsonConvert.DeserializeObject<StudentTestSave>(data);
                //if (Request.Form.Files.Count() > 0)

                if (form is not null)
                {
                    var file = (Request.Form.Files.Count() > 0) && (Request.Form.Files[0] is not null) ? Request.Form.Files[0] : null;
                    //var file = Request.Form.Files[0];
                    var response = await _inTestWriteRepository.UploadStudentAnswerDocumentAsync(form.TestId,form.StudentId,file);
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


        //[HttpGet("windowstts/{selectedVoice}/{selectedText}")]
        // public async Task<ActionResult> WindowsTTS(string selectedVoice, string selectedText)
        [HttpPost("windowstts")]
        public async Task<ActionResult> WindowsTTS(WindowsSpeechModel? winspeech)
        {
            //Task <IActionResult>
            try
            {
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

