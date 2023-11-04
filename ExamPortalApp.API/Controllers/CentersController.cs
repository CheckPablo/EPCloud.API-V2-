using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExamPortalApp.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CentersController : CrudControllerBase<CenterDto, Center>
    {
        private readonly ICenterRepository _centerRepository;
        public CentersController(ICenterRepository centerRepository, IMapper mapper) : base(mapper)
        {
            _centerRepository = centerRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<CenterDto>> Delete(int id)
        {
            try
            {
                var response = await _centerRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<CenterDto>>> Get()
        {
            try
            {
                var centers = await _centerRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<CenterDto>>(centers);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        //[HttpGet]
        [HttpGet("get-user-center/{centerId?}")]
        public  async Task<ActionResult<IEnumerable<CenterDto>>> GetCurrentUserCenterDropDown()
        {
            try
            {
                var centers = await _centerRepository.GetCenterByUser();
                var result = _mapper.Map<IEnumerable<CenterDto>>(centers);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<CenterDto>> Get(int id)
        {
            try
            {
                var center = await _centerRepository.GetAsync(id);
                var result = _mapper.Map<CenterDto>(center);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public override async Task<ActionResult<CenterDto>> Post(Center center)
        {
            try
            {
                center.Id = 0;
                var response = await _centerRepository.AddAsync(center);
                var result = _mapper.Map<CenterDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("centerSummary")]
        public async Task<ActionResult<Center[]>> GetCenterSummary()
        {
            try
            {
                // if(searcher?.SectorId == null || searcher?.SectorId == 0)
                //{
                //     searcher.StartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //     //searcher.EndExamDate == null ? DBNull.Value: DBNull.Value;
                //     //searcher.EndExamDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                // }
                var centerSummary= await _centerRepository.SearchCenterSummaryAsync();
                var result = _mapper.Map<IEnumerable<Center>>(centerSummary);
                return Ok(centerSummary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult<CenterDto>> Put(int id, Center entity)
        {
            try
            {
                var grade = await _centerRepository.UpdateAsync(entity);
                var result = _mapper.Map<CenterDto>(grade);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    
    }
}

