using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public ProvincesController(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinceDto>>> Get()
        {
            try
            {
                var provinces = await _provinceRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<ProvinceDto>>(provinces);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
