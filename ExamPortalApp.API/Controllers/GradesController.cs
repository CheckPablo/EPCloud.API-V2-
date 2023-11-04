using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradesController : CrudControllerBase<GradeDto, Grade>
    {
        private readonly IGradeRepository _gradeRepository;

        public GradesController(IGradeRepository gradeRepository, IMapper mapper) : base(mapper)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<GradeDto>> Delete(int id)
        {
            try
            {
                var response = await _gradeRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<GradeDto>>> Get()
        {
            try
            {
                var grades = await _gradeRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<GradeDto>>(grades);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<GradeDto>> Get(int id)
        {
            try
            {
                var grade = await _gradeRepository.GetAsync(id);
                var result = _mapper.Map<GradeDto>(grade);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
   
        [HttpGet("getByCenterId/{centerId}")]
        public  async Task<ActionResult<IEnumerable<GradeDto>>> GetByCenterId(int? centerId)
        {
            try
            {
                var grade = await _gradeRepository.GetAllByCenterIdAsync(centerId);
                var result = _mapper.Map <IEnumerable<GradeDto>>(grade);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<GradeDto>> Post(Grade grade)
        {
            try
            {
                grade.Id = 0; 
                var response = await _gradeRepository.AddAsync(grade);
                var result = _mapper.Map<GradeDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult<GradeDto>> Put(int id, Grade entity)
        {
            try
            {
                var grade = await _gradeRepository.UpdateAsync(entity); 
                var result = _mapper.Map<GradeDto>(grade);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}

