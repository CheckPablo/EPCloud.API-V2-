using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestSecurityLevelsController : CrudControllerBase<TestSecurityLevelDto, TestSecurityLevel>
    {
        private readonly ITestSecurityLevelRepository _testSecurityLevelRepository;

        public TestSecurityLevelsController(ITestSecurityLevelRepository testSecurityLevelRepository, IMapper mapper) : base(mapper)
        {
            _testSecurityLevelRepository = testSecurityLevelRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<TestSecurityLevelDto>> Delete(int id)
        {
            try
            {
                var response = await _testSecurityLevelRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<TestSecurityLevelDto>>> Get()
        {
            try
            {
                var testSecurityLevels = await _testSecurityLevelRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<TestSecurityLevelDto>>(testSecurityLevels);

                return Ok(testSecurityLevels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<TestSecurityLevelDto>> Get(int id)
        {
            try
            {
                var testSecurityLevel = await _testSecurityLevelRepository.GetAsync(id);
                var result = _mapper.Map<TestSecurityLevelDto>(testSecurityLevel);

                return Ok(testSecurityLevel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<TestSecurityLevelDto>> Post(TestSecurityLevel testSecurityLevel)
        {
            try
            {
                var response = await _testSecurityLevelRepository.AddAsync(testSecurityLevel);
                var result = _mapper.Map<TestSecurityLevelDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<TestSecurityLevelDto>> Put(int id, TestSecurityLevel entity)
        {
            throw new NotImplementedException();
        }
    }
}

