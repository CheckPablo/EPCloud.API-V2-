using AutoMapper;
using AutoMapper.Execution;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CenterAttendanceController : ControllerBase
    {
        private readonly ICenterAttendanceRepository _centerAttendanceRepository;
        private readonly IMapper _mapper;

        public CenterAttendanceController(ICenterAttendanceRepository centerAttendanceRepository, IMapper mapper)
        {
            _centerAttendanceRepository = centerAttendanceRepository;
            _mapper = mapper;
        }

        [HttpPost("centerAttendance")]
        public async Task<ActionResult<CenterAttendance[]>> GetCenterAttendance(CenterAttendanceSearcher? searcher)
        {
            try
            {
               // if(searcher?.SectorId == null || searcher?.SectorId == 0)
               //{
               //     searcher.StartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               //     //searcher.EndExamDate == null ? DBNull.Value: DBNull.Value;
               //     //searcher.EndExamDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               // }
                var centerAttendance = await _centerAttendanceRepository.SearchAsync(searcher);
                var result = _mapper.Map<IEnumerable<CenterAttendance>>(centerAttendance);
                return Ok(centerAttendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
