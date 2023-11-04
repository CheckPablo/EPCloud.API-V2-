using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserManagementController : CrudControllerBase<UserDto, User>
    {
        private readonly IUserManagementRepository _userRepository;
        private readonly IRepository _repository;

        public UserManagementController(IUserManagementRepository userRepository, IMapper mapper) : base(mapper)
        {
            _userRepository = userRepository;
        }

        [HttpPost("bulk-user-update")]
        public async Task<ActionResult<UserDto>> BulkUserUpdate(BulkUserUpdate bulkUserUpdate)
        {
            try
            {
                await _userRepository.UpdateUsersAsync(bulkUserUpdate);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<UserDto>> Delete(int id)
        {
            try
            {
                var response = await _userRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<UserDto>> Get(int id)
        {
            try
            {
                var user = await _userRepository.GetAsync(id);
                var result = _mapper.Map<UserDto>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-center/{centerId?}")]
        public async Task<ActionResult<UserDto>> GetUsersByCenter(int? centerId)
        {
            try
            {
                var users = await _userRepository.GetUsersByCenterAsync(centerId);
                var result = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<UserDto>> Post(User user)
        {
            try
            {
                var response = await _userRepository.AddAsync(user);
                var result = _mapper.Map<UserDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult<UserDto>> Put(int id, User entity)
        {
            try
            {
                var response = await _userRepository.UpdateAsync(entity);
                var result = _mapper.Map<UserDto>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           // return await _userRepository.UpdateAsync(entity, true);
            //throw new NotImplementedException();
        }
            
        [HttpPost("reset-password")]
        public async Task<ActionResult<UserDto>> ResetPassword(PasswordResetter resetter)
        {
            try
            {
                var user = await _userRepository.ResetPasswordAsync(resetter);
                var result = _mapper.Map<UserDto>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search/{activeState}/{approvedState}")]
        public async Task<ActionResult<UserCenter[]>> Search(string activeState, string approvedState)
        {   //var user = await _repository.GetFirstOrDefaultAsync<User>(x => x.Username == username);
           // var centerType = await _repository.GetFirstOrDefaultAsync<Center>(x => x.Id == user.CenterId);
            try
            {
                var user = await _userRepository.SearchAsync(activeState, approvedState);

                //foreach(var item in user)
                //{
                //    var center = await _repository.GetByIdAsync<Center>(item.CenterId);                  
                //    center.Name
                //}
          
                //var centerType = await _repository.GetFirstOrDefaultAsync<Center>(x => x.Id == user.CenterId);
                var result = _mapper.Map<IEnumerable<UserCenter>>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

