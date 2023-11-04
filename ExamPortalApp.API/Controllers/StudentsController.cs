using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentManagementRepository, IMapper mapper)
        {
            _studentRepository = studentManagementRepository;
            _mapper = mapper;
        }

        [HttpPost("create-login-credentials")]
        public ActionResult CreateLoginCredentials(int[] studentIds)
        {
            try
            {
                var result = _studentRepository.CreateLoginCredentials(studentIds);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDto>> Delete(int id)
        {
            try
            {
                var response = await _studentRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<StudentDto>>(students);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var student = await _studentRepository.GetAsync(id);
                var result = _mapper.Map<StudentDto>(student);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-invigilator/{userId}/{gradeId?}/{subjectId?}")]
        public async Task<ActionResult<IEnumerable<InvigilatorStudentLinkResult>>> GetByInvigilator(int userId, int? gradeId, int? subjectId)
        {
            try
            {
                var links = await _studentRepository.GetInvigilatorStudentLinksAsync(userId, gradeId, subjectId);

                return Ok(links);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    [HttpPost("{id}/link-to-subjects")]
        public async Task<ActionResult> LinkStudentToSubjects(int id, int[] subjectIds)
        {
            try
            {
                await _studentRepository.LinkStudentToSubjectsAsync(id, subjectIds);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/delink-from-subjects")]
        public async Task<ActionResult> DeinkStudentFromSubjects(int id, int[] subjectIds)
        {
            try
            {
                await _studentRepository.DelinkStudentToSubjectsAsync(id, subjectIds);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("search-students")]
        public async Task<ActionResult> SeachStudentsAsync([FromQuery] StudentSearcher searcher)
        {
            try
            {
                var students = await _studentRepository.SearchAsync(searcher);
                var result = _mapper.Map<IEnumerable<StudentDto>>(students);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("send-login-credentials")]
        public ActionResult SendLoginCredentials(int[] studentIds)
        {
            try
            {
                var result = _studentRepository.SendLoginCredentials(studentIds);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post(StudentDto studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var response = await _studentRepository.AddAsync(student);
                var result = _mapper.Map<StudentDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Put(int id, Student student)
        {
            try
            {
                var response = await _studentRepository.UpdateAsync(student);
                var result = _mapper.Map<StudentDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        //[HttpPost("{id}")]
        [HttpPost("{id}/update-student")]
        //public async Task<ActionResult<StudentDto>> Post(int id, Student student)
        public async Task<ActionResult<StudentDto>> Post(Student student)
        {
            try
            {
                var response = await _studentRepository.UpdateAsync(student);
                var result = _mapper.Map<StudentDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

