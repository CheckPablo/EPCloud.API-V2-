using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectsController : CrudControllerBase<SubjectDto, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository, IMapper mapper) : base(mapper)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpPost("link-subject-allstudents")]
        public  async Task<ActionResult<SubjectDto>> LinkSubjectAllStudents(Subject subject)
        {
            try
            {
                //the line below can be removed once we can reset id to 0 from UI for a new insert 
                subject.Id = 0;
                var response = await _subjectRepository.AddLinkToAllAsync(subject);
                var result = _mapper.Map<SubjectDto>(response);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("subject-update")]
        //public async Task<ActionResult<GradeDto>> SubjectUpdate(Subject subject)
        public async Task<ActionResult<SubjectDto>> SubjectUpdate(Subject subject)

        {
            //return NoContent();
            try
            {
                await _subjectRepository.UpdateAsync(subject);
                //await _subjectRepository.AddLinkToAllAsync(subject);
                // await _gradeRepository.UpdateGradesAsync(grade);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("link-subjectupdate-allstudents")]
        public async Task<ActionResult<SubjectDto>> UpdateLinkSubjectAllStudents(Subject subject)
        {
            try
            {
                //the line below can be removed once we can reset id to 0 from UI for a new insert 
                //subject.Id = 0;
                var response = await _subjectRepository.UpdateLinkToAllAsync(subject);
                var result = _mapper.Map<SubjectDto>(response);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public override async Task<ActionResult<SubjectDto>> Delete(int id)
        {
            try
            {
                var response = await _subjectRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<SubjectDto>>> Get()
        {
            try
            {
                var Subjects = await _subjectRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<SubjectDto>>(Subjects);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<SubjectDto>> Get(int id)
        {
            try
            {
                var Subject = await _subjectRepository.GetAsync(id);
                var result = _mapper.Map<SubjectDto>(Subject);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-grade/{id}")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetByGrade(int id)
        {
            try
            {
                var subjects = await _subjectRepository.GetByGradeAsync(id);
                var result = _mapper.Map<IEnumerable<SubjectDto>>(subjects);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-student/{id}")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetBySudent(int id)
        {
            try
            {
                var subjects = await _subjectRepository.GetByStudentAsync(id);
                var result = _mapper.Map<IEnumerable<SubjectDto>>(subjects);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public override async Task<ActionResult<SubjectDto>> Post(Subject subject)
        {
            try
            {
                //the line below can be removed once we can reset id to 0 from UI for a new insert 
                subject.Id = 0; 
                var response = await _subjectRepository.AddAsync(subject);
                var result = _mapper.Map<SubjectDto>(response);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult<SubjectDto>> Put(int id, Subject entity)
        {
            try
            {
                var grade = await _subjectRepository.UpdateAsync(entity);
                var result = _mapper.Map<SubjectDto>(grade);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}