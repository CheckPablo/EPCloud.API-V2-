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
    public class TestTypesController : CrudControllerBase<TestTypeDto, TestType>
    {
        private readonly ITestTypeRepository _testTypeRepository;

        public TestTypesController(ITestTypeRepository testTypeRepository, IMapper mapper) : base(mapper)
        {
            _testTypeRepository = testTypeRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<TestTypeDto>> Delete(int id)
        {
            try
            {
                var response = await _testTypeRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<TestTypeDto>>> Get()
        {
            try
            {
                var testTypes = await _testTypeRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<TestTypeDto>>(testTypes);

                return Ok(testTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<TestTypeDto>> Get(int id)
        {
            try
            {
                var testType = await _testTypeRepository.GetAsync(id);
                var result = _mapper.Map<TestTypeDto>(testType);

                return Ok(testType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<TestTypeDto>> Post(TestType testType)
        {
            try
            {
                var response = await _testTypeRepository.AddAsync(testType);
                var result = _mapper.Map<TestTypeDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override  Task<ActionResult<TestTypeDto>> Put(int id, TestType entity)
        {
            throw new NotImplementedException();
           
        }


    }
}

