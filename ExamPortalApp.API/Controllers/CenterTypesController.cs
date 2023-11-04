using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterTypesController : ControllerBase
    {
        private readonly ICenterTypeRespository _centerTypeRepository;
        private readonly IMapper _mapper;

        public CenterTypesController(ICenterTypeRespository centerTypeRepository, IMapper mapper)
        {
            _centerTypeRepository = centerTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenterTypeDto>>> Get()
        {
            try
            {
                var centerTypes = await _centerTypeRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<CenterTypeDto>>(centerTypes);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
