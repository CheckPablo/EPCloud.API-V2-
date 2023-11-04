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
    public class AttendanceRegisterController : ControllerBase
    {
        private readonly IAttendanceRegisterRepository _attendanceRegisterRepository;
        private readonly IMapper _mapper;

        public AttendanceRegisterController(IAttendanceRegisterRepository attendanceRegisterRepository, IMapper mapper)
        {
            _attendanceRegisterRepository = attendanceRegisterRepository;
            _mapper = mapper;
        }

        [HttpPost("attendanceRegister")]
        public async Task<ActionResult<AttendanceRegister[]>> GetAttendanceRegister(int centerId, int sectorId, int subjectId, int testId)
        {
            try
            {
                var attendanceRegisters = await _attendanceRegisterRepository.SearchAsync(centerId, sectorId, subjectId, testId);
                var result = _mapper.Map<IEnumerable<AttendanceRegister>>(attendanceRegisters);
                return Ok(attendanceRegisters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setStudentAbsentism")]
        public async Task<ActionResult<AttendanceRegister>> SetStudentAbsentism(int studentId, int testId, int absent)
        {
            try
            {
                await _attendanceRegisterRepository.SetStudentAbsentism(studentId, testId, absent);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("resetTest")]
        public async Task<ActionResult<AttendanceRegister>> ResetTest(int studentId, int testId)
        {
            try
            {
                await _attendanceRegisterRepository.ResetTest(studentId, testId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
