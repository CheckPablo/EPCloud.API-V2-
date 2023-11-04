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
    public class LanguagesController : CrudControllerBase<LanguageDto, Language>
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguagesController(ILanguageRepository languageRepository, IMapper mapper) : base(mapper)
        {
            _languageRepository = languageRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<LanguageDto>> Delete(int id)
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
        public override async Task<ActionResult<IEnumerable<LanguageDto>>> Get()
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
        public override async Task<ActionResult<LanguageDto>> Get(int id)
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
        public override async Task<ActionResult<LanguageDto>> Post(Language Language)
        {
            try
            {
                var response = await _languageRepository.AddAsync(Language);
                var result = _mapper.Map<LanguageDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<LanguageDto>> Put(int id, Language entity)
        {
            throw new NotImplementedException();
        }
    }
}

