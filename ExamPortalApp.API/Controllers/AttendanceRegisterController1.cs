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
    public class AttendanceRegistersController : CrudControllerBase<AttendanceRegister, StudentTest>
    {
        private readonly ILanguageRepository _languageRepository;

        public AttendanceRegistersController(ILanguageRepository languageRepository, IMapper mapper) : base(mapper)
        {
            _languageRepository = languageRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<AttendanceRegister>> Delete(int id)
        {
            try
            {
                var response = await _languageRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<AttendanceRegister>>> Get()
        {
            try
            {
                var Languages = await _languageRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<LanguageDto>>(Languages);

                return Ok(Languages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<AttendanceRegister>> Get(int id)
        {
            try
            {
                var Language = await _languageRepository.GetAsync(id);
                var result = _mapper.Map<LanguageDto>(Language);

                return Ok(Language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
        [HttpPost]
        public override Task<ActionResult<AttendanceRegister>> Post(StudentTest entity)
        {
            throw new NotImplementedException();
        }

     
        [HttpPut("{id}")]
        public override Task<ActionResult<AttendanceRegister>> Put(int id, StudentTest entity)
        {
            throw new NotImplementedException();
        }
    }
}

