using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IAuthRepository
    {

        Task<LoggedUser> LoginAsync(string username, string password, int impersonatedCenterId, string adminPwd);
        Task<LoggedUser> LoginAsync(LoginModel loginModel);
        Task<LoggedUser> LoginStudentAsync(string examNo, string password);
        Task<LoggedUser> LoginStudentAsync(string email);
        Task<LoggedUser> LoginStudentAsync(StudentLoginModel loginModel);

        //Task<LoggedUser> LoginAdminAsync(string username, int impersonatedCenterId);
        //Task<LoggedUser> LoginAdminAsync(AdminLoginModel loginModel);
      
        Task<User> RegisterAsync(RegisterModel model);
        Task<User> ResetUserPasswordAsync(User user, string password);
        //Task<LoggedUser> SignOutAuthenticatedUser(string? username, int role);
        //Task<bool> LogOut(int centerId); 
    }
}
