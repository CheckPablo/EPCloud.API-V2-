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
    public class InvigilatorStudentLinkController : CrudControllerBase<InvigilatorStudentLinkDto, InvigilatorStudentLink>
    {
        private readonly IInvigilatorStudentLinkRepository _invigilatorStudentLinkRepository;

        public InvigilatorStudentLinkController(IInvigilatorStudentLinkRepository invigilatorStudentLinkRepository, IMapper mapper) : base(mapper)
        {
            _invigilatorStudentLinkRepository = invigilatorStudentLinkRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<InvigilatorStudentLinkDto>> Delete(int id)
        {
            try
            {
                var response = await _invigilatorStudentLinkRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<InvigilatorStudentLinkDto>>> Get()
        {
            try
            {
                var links = await _invigilatorStudentLinkRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<InvigilatorStudentLinkDto>>(links);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<InvigilatorStudentLinkDto>> Get(int id)
        {
            try
            {
                var user = await _invigilatorStudentLinkRepository.GetAsync(id);
                var result = _mapper.Map<UserDto>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("link-students")]
        public async Task<ActionResult<bool>> LinkStudents(InvigilatorStudentLinker linker)
        {
            try
            {
                var result = await _invigilatorStudentLinkRepository.LinkStudentsAsync(linker);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<InvigilatorStudentLinkDto>> Post(InvigilatorStudentLink invigilatorStudentLink)
        {
            try
            {
                var response = await _invigilatorStudentLinkRepository.AddAsync(invigilatorStudentLink);
                var result = _mapper.Map<InvigilatorStudentLinkDto>(response);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<InvigilatorStudentLinkDto>> Put(int id, InvigilatorStudentLink entity)
        {
            throw new NotImplementedException();
        }
    }
}

