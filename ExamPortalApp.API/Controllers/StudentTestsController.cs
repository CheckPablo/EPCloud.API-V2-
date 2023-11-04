using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
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
    public class StudentTestsController : CrudControllerBase<StudentTestDTO, StudentTest>
    {
        private readonly IStudentTestRepository _studentTestRepository;

        public StudentTestsController(IStudentTestRepository studentTestRepository, IMapper mapper) : base(mapper)
        {
            _studentTestRepository  =studentTestRepository;
        }


        [HttpPost("accept-disclaimer")]
        public async Task<ActionResult> AcceptDisclaimer(int testId, int studentId, bool isDisclaimerAccepted)
        {
            try
            {
                var result = await _studentTestRepository.AcceptDisclaimer(testId, studentId, isDisclaimerAccepted);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save-answers-interval")]
        public async Task<ActionResult<StudentTestAnswers>> SaveAnswersInterval(StudentTestAnswerModel studentTestAnswers)
        {
            try
            {
                var result = await _studentTestRepository.SaveAnswersInterval(studentTestAnswers);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<StudentTestDTO>> Delete(int id)
        {
            try
            {
                var response = await _studentTestRepository.DeleteAsync(id);

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
                var testSecurityLevels = await _studentTestRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<TestSecurityLevelDto>>(testSecurityLevels);

                return Ok(testSecurityLevels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<StudentTestDTO>> Get(int id)
        {
            try
            {
                var testSecurityLevel = await _studentTestRepository.GetAsync(id);
                var result = _mapper.Map<TestSecurityLevelDto>(testSecurityLevel);

                return Ok(testSecurityLevel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-students-testdetails")]
        public async Task<ActionResult<StudentTestAnswers>> GetStudentTestDetails(int testId, int studentId)
        {
            try
            {
                var result = await _studentTestRepository.GetStudentTestDetails(testId, studentId);
                //result.
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public override async Task<ActionResult<StudentTestDTO>> Post(StudentTest studentTest)
        {
            try
            {
                var response = await _studentTestRepository.AddAsync(studentTest);
                var result = _mapper.Map<StudentTestDTO>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public override Task<ActionResult<StudentTestDTO>> Put(int id, StudentTest entity)
        {
            throw new NotImplementedException();
        }
    }
}

