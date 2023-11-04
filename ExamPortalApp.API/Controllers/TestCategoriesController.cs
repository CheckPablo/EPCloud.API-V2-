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
    public class TestCategoriesController : CrudControllerBase<TestCategoryDto, TestCategory>
    {
        private readonly ITestCategoryRepository _testCategoryRepository;

        public TestCategoriesController(ITestCategoryRepository testCategoryRepository, IMapper mapper) : base(mapper)
        {
            _testCategoryRepository = testCategoryRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<TestCategoryDto>> Delete(int id)
        {
            try
            {
                var response = await _testCategoryRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<TestCategoryDto>>> Get()
        {
            try
            {
                var testCategorys = await _testCategoryRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<TestCategoryDto>>(testCategorys);

                return Ok(testCategorys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<TestCategoryDto>> Get(int id)
        {
            try
            {
                var testCategory = await _testCategoryRepository.GetAsync(id);
                var result = _mapper.Map<TestCategoryDto>(testCategory);

                return Ok(testCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<TestCategoryDto>> Post(TestCategory testCategory)
        {
            try
            {
                var response = await _testCategoryRepository.AddAsync(testCategory);
                var result = _mapper.Map<TestCategoryDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<TestCategoryDto>> Put(int id, TestCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}

