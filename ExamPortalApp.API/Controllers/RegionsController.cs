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
    public class RegionsController : CrudControllerBase<RegionDto, Region>
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper) : base(mapper)
        {
            _regionRepository = regionRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<RegionDto>> Delete(int id)
        {
            try
            {
                var response = await _regionRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<RegionDto>>> Get()
        {
            try
            {
                var regions = await _regionRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<RegionDto>>(regions);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<RegionDto>> Get(int id)
        {
            try
            {
                var region = await _regionRepository.GetAsync(id);
                var result = _mapper.Map<RegionDto>(region);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<RegionDto>> Post(Region region)
        {
            try
            {
                var response = await _regionRepository.AddAsync(region);
                var result = _mapper.Map<RegionDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<RegionDto>> Put(int id, Region entity)
        {
            throw new NotImplementedException();
        }
    }
}
