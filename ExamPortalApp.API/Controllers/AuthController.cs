using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using ExamPortalApp.Infrastructure.Constants;

namespace ExamPortalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;
        private readonly IMapper _mapper;
        //private readonly IJwtAuthManager _jwtAuthManager;

        public AuthController(IAuthRepository authRepository, IMapper mapper)
        {
            _auth = authRepository;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            try
            {
                var user = await _auth.LoginAsync(loginModel);
                /*if (user== null)
                {
                   throw new Exception("Login credentials are incorrect"); //password length error
                }*/
                return Ok(user);
            }
            catch(UserNotFoundException ex)
            {

                return Unauthorized(ex.Message);
                //throw new StudentNotFoundException("The user cannot be found", "Please double check your credentials");
                //throw new System.Exception(ex.Message);
                //  throw new System.Exception(ex.Message);
                //throw new StudentNotFoundException("The user cannot be found", "Please double check your credentials");
                //throw new Exception(ex.Message); //password length error
                //return Unauthorized(ex.Message);
                //throw new Exception("Something has gone haywire!");
           
            }

            /*finally
               {
                throw new System.ArgumentException("Parameter cannot be null", "original");
                //throw new StudentNotFoundException("The user cannot be found", "Please double check your credentials");
                throw new System.Exception("The user cannot be found" +""+ "Please double check your credentials");
            }*/
        }

        //[HttpPost("LoginAdmin")]
        //public async Task<ActionResult> LoginAdmin(AdminLoginModel adminLogonModel)
        //{
        //    try
        //    {
        //        var user = await _auth.LoginAdminAsync(adminLogonModel);

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //}

        [HttpPost("LoginStudent")]
        public async Task<ActionResult> LoginStudent(StudentLoginModel loginModel)
        {
            try
            {
                loginModel.Password.Trim(); 
                var user = await _auth.LoginStudentAsync(loginModel);

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
                //return Unauthorized(ex.Message);
            }
        }

        [HttpPost("LoginStudentExternal")]
        public async Task<ActionResult> LoginStudentExternal(string email)
        {
            try
            {
                var user = await _auth.LoginStudentAsync(email);

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Unauthorized(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            try
            {
                var user = await _auth.RegisterAsync(model);
                var result = _mapper.Map<UserDto>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("Logout")]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Logout()
        //{
        //    var userName = User.Identity.Name;
        //    int role = 0; 
        //    //try
        //    //{
        //    //    _auth.LogOut(0);
        //    //    return Ok(); 
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return BadRequest(ex.Message);
        //    //}
        //    var signout = await _auth.SignOutAuthenticatedUser(userName, role ); 
        //    //var userName = User.Identity.Name;
        //    //var tokenHandler = new JwtSecurityTokenHandler();
        //    //var token = tokenHandler.CreateToken(tokenDescriptor);
        //    //_jwtAuthManager.RemoveRefreshTokenByUserName(userName); // can be more specific to ip, user agent, device name, etc.
        //    // _logger.LogInformation($"User [{userName}] logged out the system.");
        //    return Ok();
        //    //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);*/
        //}
    }

}
