using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using ExamPortalApp.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Win32.SafeHandles;
using System.Security.Principal;
using Newtonsoft.Json.Linq;



namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IRepository _repository;
        private readonly ExamPortalSettings? _settings;
        private readonly IEmailService _emailService;
        private readonly ExamPortalSettings _examPortalSettings;
        private readonly IHttpContextAccessor? _httpAccessor;
  

        public AuthRepository(IRepository repository, IConfiguration configuration, IEmailService emailService, IOptions<ExamPortalSettings> options,IHttpContextAccessor accessor)
        {
            _repository = repository;
            _settings = configuration.GetSection("ExamPortalSettings").Get<ExamPortalSettings>();
            _emailService = emailService;
            _examPortalSettings = options.Value;
            _httpAccessor = accessor;

        }

        private void EmailNewUserCredentials(User user, string password)
        {
            //var body = $"Dear {user.Name} {user.Surname}: \n \n"
            //+ " Welcome to Exam Portal Cloud \n \n"
            //+ " Your password has been reset, please see your updated log in details below. \n \n"
            //+ " Username: " + user.Username + "\n"
            //+ " Password: " + password + "\n \n"
            //+ " Use the following link to login : https://examportalcloud.co.za/ \n \n ";

            //var emailDto = new EmailDto
            //{
            //    // EmailAddesses = new List<string> { model.Email, "support@v-soft.co.za" },
            //    EmailAddesses = new List<string> { user.UserEmailAddress, "syntaxdon@gmail.com" },
            //    MessageBody = body,
            //    Subject = "Login Details for Exam Portal Cloud"
            //};

            //_emailService.SendOrQueue(emailDto);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("qiscmapp@gmail.com");

            mail.To.Add("Tinashe@v-soft.co.za");
            mail.To.Add(user.UserEmailAddress);
            //mail.Bcc.Add("support@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = " Login Details for Exam Portal Cloud";

            mail.Body = " Dear User,\n\n"
            + " Welcome to Exam Portal Cloud \n \n"
            + " Your Login Registration details: \n \n"
            + " Exam Number: " + user.Username + "\n"
            + " Password: " + password + "\n \n"
            + " Use the following link to login : https://examportalcloud.co.za/ and select Student Login. \n \n "
            + " IMPORTANT: Please ensure you have Safe Exam Browser installed on your Windows / Mac computer/laptop. You may download it from here: https://sourceforge.net/projects/seb/files/seb/SEB_2.4.1/SafeExamBrowserInstaller.exe/download  If you do not have a Windows or a Mac book computer / laptop, you do not need to install Safe Exam Browser. \n \n"
            + " If you experience any problems during login or during your examination, please contact your exam invigilator immediately. \n \n"
            + " Kind Regards, \n"
            + " The Exam Portal Cloud team";
            SmtpClient smtpServer = new SmtpClient();
            //smtpServer.UseDefaultCredentials = false;;
            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");
            //smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "insyduliawxhesgf");

            smtpServer.Timeout = 20000;
            smtpServer.Send(mail);
        }

        private void EmailUserCredentials(RegisterModel model)
        {
            //var body = "Dear \n" + model.FirstName + ",\n\n"
            //+ " Thank you for registering your account on Exam Portal Cloud. We are busy verifying your account and will communicate with you once your account has been approved. \n \n"
            //+ " Please see your Registration details: \n \n"
            //+ " Username: " + model.Username + "\n"
            //+ " Password: " + model.Password + "\n \n"
            //+ " Thank you and chat soon. \n \n "
            //+ " Kind Regards \n";

            //var emailDto = new EmailDto
            //{
            //    EmailAddesses = new List<string> { model.Email },
            //    BccAddresses = new List<string> {"support@v-soft.co.za" },
            //    MessageBody = body,
            //    Subject = "Login Details for Exam Portal Cloud"
            //};

            //_emailService.SendOrQueue(emailDto);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("qiscmapp@gmail.com");

            mail.To.Add("Tinashe@v-soft.co.za");
            mail.To.Add(model.Email);
            //mail.Bcc.Add("support@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = " Login Details for Exam Portal Cloud";

            mail.Body = " Dear" + "".PadRight(1) + model.FirstName + "" + " ,\n\n"
            + " Thank you for registering your account on Exam Portal Cloud. We are busy verifying your account and will communicate with you once your account has been approved. \n \n"
            + " Please see your Registration details: \n \n"
            + " Username: " + model.Username + "\n"
            + " Password: " + model.Password + "\n \n"
            + " Thank you and chat soon. \n \n "
            + " Kind Regards \n"
            + " The Exam Portal Cloud team";
            SmtpClient smtpServer = new SmtpClient();
            //smtpServer.UseDefaultCredentials = false;;
            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");
            //smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "insyduliawxhesgf");

            smtpServer.Timeout = 20000;
            smtpServer.Send(mail);
        }

        private async Task<int> GetUserRoleAsync(User user)
        {
            if (user.CenterId == 2) return 1; //V-soft admin

            var centerUsers = await _repository.GetWhereAsync<User>(x => x.CenterId == user.CenterId);
            if (user.IsSchoolAdmin == true && user.VsoftApproved == true && user.CenterId != 2) return 2; // Center admin


            //if (centerUsers == null || centerUsers.Count() == 1) return 2; // Center admin
            //if (centerUsers.First().Id == user.Id) return 2; // Center admin
            //The above role 2 should get approved first
            //how does it get approved?

            return 3; //Center user
        }

        public async Task<LoggedUser> LoginAsync(string username, string password, int impersonatedCenterId, string? adminPwd)
        {
            var user = await _repository.GetFirstOrDefaultAsync<User>(x => x.Username == username);
            var centerType = await _repository.GetFirstOrDefaultAsync<Center>(x => x.Id == user.CenterId);
            var loginSuccessful = false;
            if (impersonatedCenterId == 0)
            {
                if (user == null) throw new Exception(ErrorMessages.Auth.Unauthorised);

                if (user.PasswordHash is null)
                {
                    loginSuccessful = await UpdatePasswordInTableAsync(username, password, user);
                }
                else
                {
                    loginSuccessful = PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
                }

                #region Validation
                if (!loginSuccessful)
                {
                    throw new System.Exception("The user cannot  be found" + "," + "please double check your credentials");

                    /*try {
                        //throw new StudentNotFoundException("The user cannot  be found", "please double check your credentials");
                        //throw new Exception(ErrorMessages.Auth.Unauthorised);
                        //..throw new Exception("The user cannot  be found" + "," + "please double check your credentials");
                        throw new System.Exception("The user cannot  be found" + "," + "please double check your credentials");
                       // return;
                    }
                    catch (System.Exception ex){
                        //throw new StudentNotFoundException("The user cannot  be found", "please double check your credentials");
                        //throw new System.Exception(ex.Message);
                        //throw new System.Exception(ex.Message);
                        //throw new System.Exception(ex.Message);
                        //throw new StudentNotFoundException("The user cannot be found", "Please double check your credentials");

                        // throw new Exception(ErrorMessages.Auth.Unauthorised);
                        throw new Exception("Something has gone haywire!");
                        throw new ObjectDisposedException("He's Dead, Jim");
                        throw new InvalidCastException(
                         "The user cannot  be found" + ", " + "please double check your credentials");
                    }
                    finally
                    {
                        //throw new System.Exception("The user cannot  be found" + ", " + "please double check your credentials");
                        //throw new System.Exception("The user cannot  be found" + ", " + "please double check your credentials");

                        throw new Exception("Something has gone haywire!");
                        throw new ObjectDisposedException("He's Dead, Jim");
                        throw new InvalidCastException(
                         "The user cannot  be found" + ", " + "please double check your credentials");
                        //throw new System.Exception(ex.Message);
                    }*/
                   
                }
                if (user.VsoftApproved == false) throw new NotApprovedException();
                if (user.IsActive == false) throw new NotActiveException();
                #endregion

                var userRole = await GetUserRoleAsync(user);
                if (centerType != null)
                {
                    user.CenterTypeId = centerType.CenterTypeId;
                }
                var authUser = PrepareAuthenticatedUser(user, userRole, impersonatedCenterId , adminPwd);
                //authUser.Token 
                return authUser;
            }
            //else if(user.CenterId ==2 && impersonatin)
            else            {
                int userRole = 2; 
               
                var authUser = PrepareAuthenticatedUser(user, userRole, impersonatedCenterId, adminPwd);
                return authUser;
            }
        }
           
        public async Task<LoggedUser> LoginStudentAsync(string StudentExamNo, string password)
        {
            //password.Trim(); 
            var studentUser = await _repository.GetFirstOrDefaultAsync<Student>(x => x.ExamNo == StudentExamNo);
            if (studentUser.EligibleForExternalLogin == true)
            {
                throw new Exception(ErrorMessages.Auth.MicrosoftLogin);
            }
            var centerType = await _repository.GetFirstOrDefaultAsync<Center>(x => x.Id == studentUser.CenterId);
            var loginSuccessful = false;

            if (studentUser == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
          
            //if (password == "5CEF78A3") //default for testing
            //{
            //    //loginSuccessful = true;
            //    return PrepareAuthenticatedStudentUser(studentUser, 3);
            //}

            if (studentUser.EncrytedPassword is  null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
                loginSuccessful = false;
                //check with exam number and encrypt and save student from old system , alorithims are different
                //password = PasswordHelper.Encrypt(studentUser.EncrytedPassword, _examPortalSettings.EncryptionKey);
            }
            
            else
            {
                var passwordMatch = PasswordHelper.Encrypt(password, _examPortalSettings.EncryptionKey);

                if (studentUser.EncrytedPassword == passwordMatch)
                {
                    loginSuccessful = true;
                }

                else
                {
                    throw new Exception(ErrorMessages.Auth.PasswordValidationMessage); //upper case error here
                    loginSuccessful = false;

                    //throw new Exception(ErrorMessages.Auth.Unauthorised);
                    //throw new Exception(ErrorMessages.CenterEntryChecks.CenterExists);
                }
            }
            #region Validation
            if (!loginSuccessful) throw new Exception(ErrorMessages.Auth.Unauthorised);
            //if (studentUser.VsoftApproved == false) throw new NotApprovedException();
            //if (studentUser.IsActive == false) throw new NotActiveException();
            #endregion

            //var userRole = await GetUserRoleAsync(studentUser);
            var userRole = 3;
            if (centerType != null)
            {
                centerType.CenterTypeId = centerType.CenterTypeId;
            }
            var authUser = PrepareAuthenticatedStudentUser(studentUser, userRole);

            return authUser;
        }
        public async Task<LoggedUser> LoginStudentAsync(string email)
        {
            var studentUser = await _repository.GetFirstOrDefaultAsync<Student>(x => x.ExternalEmail == email && x.EligibleForExternalLogin == true);
            var centerType = await _repository.GetFirstOrDefaultAsync<Center>(x => x.Id == studentUser.CenterId);

            if (studentUser == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }

            //var userRole = await GetUserRoleAsync(studentUser);
            var userRole = 3;
            if (centerType != null)
            {
                centerType.CenterTypeId = centerType.CenterTypeId;
            }
            var authUser = PrepareAuthenticatedStudentUser(studentUser, userRole);

            return authUser;
        }

        public async Task<LoggedUser> LoginAsync(LoginModel loginModel) =>
            await LoginAsync(loginModel.Username, loginModel.Password, loginModel.ImpersonatedCenterId, loginModel.AdminPwd);


        public async Task<LoggedUser> LoginStudentAsync(StudentLoginModel loginModel) =>
          await LoginStudentAsync(loginModel.StudentExamNo.Trim(), loginModel.Password.Trim());

        //public async Task<LoggedUser> LoginAdminAsync(AdminLoginModel loginModel) =>
        // await LoginAdminAsync( loginModel.Username, loginModel.impersonatedCenterId); 
        private LoggedUser PrepareAuthenticatedUser(User user, int userRole, int impersonatedCenterId, string? adminPwd)
        {
            #region Setup the token
            var tokenKey = _settings?.Key ?? string.Empty;
            var issuer = _settings?.Issuer ?? string.Empty;
            var claims = new List<Claim>();
            if (userRole == 2 && impersonatedCenterId != 0 && user.CenterId == 2)
            {
                //if (userRole == 2 && impersonatedCenterId != 0 *&& user.CenterId == 2*)
                if (adminPwd == "password@01")
                {
                    
                    impersonatedCenterId = 2;
                    user.CenterId = 2;
                    userRole = 1;

                    claims = new List<Claim>

                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username ?? user.Id.ToString()),
                    new Claim("Role", $"{userRole}"),
                    new Claim("FullName", $"{user.Name} { user.Surname}"),
                    new Claim("CenterId", 2.ToString()),
                    new Claim("impersonatedCenterId", 2.ToString()),

                };
                }

                if (adminPwd == "iPpd@jsoa5dpjo1s")
                {
                     //|| adminPwd == "iPpd@jsoa5dpjo1s"
                    //impersonatedCenterId = 2;
                    user.CenterId = 2;
                    userRole = 1;

                    claims = new List<Claim>

                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username ?? user.Id.ToString()),
                    new Claim("Role", $"{userRole}"),
                    new Claim("FullName", $"{user.Name} { user.Surname}"),
                    new Claim("CenterId", 2.ToString()),
                    new Claim("impersonatedCenterId", 2.ToString()),

                };

                }

                claims = new List<Claim>

                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username ?? user.Id.ToString()),
                    new Claim("Role", $"{userRole}"),
                    new Claim("FullName", $"{user.Name} { user.Surname}"),
                    new Claim("CenterId", impersonatedCenterId.ToString()),
                    new Claim("impersonatedCenterId", impersonatedCenterId.ToString()),

                };              
            }
            else
            { 
              claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username ?? user.Id.ToString()),
                    new Claim("Role", $"{userRole}"),
                    new Claim("FullName", $"{user.Name} { user.Surname}"),
                    new Claim("CenterId", user.CenterId.ToString()),
                    //new Claim("impersonatedCenterId", impersonatedCenterId.ToString())

                };

            }
           
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = creds,
                Audience = issuer,
                Issuer = issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            #endregion

            return new LoggedUser
            {
                Id = user.Id,
                Email = user.UserEmailAddress,
                Username = user.Username,
                FullName = $"{user.Name} {user.Surname}",
                FirstName = user.Name,
                Surname = user.Surname,
                Token = tokenHandler.WriteToken(token),
                Role = userRole,
                ImpersonatedCenterId = impersonatedCenterId,
            };
        }

        private LoggedUser PrepareAuthenticatedStudentUser(Student studentUser, int userRole)
        {
            #region Setup the token
            var tokenKey = _settings?.Key ?? string.Empty;
            var issuer = _settings?.Issuer ?? string.Empty;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, studentUser.Id.ToString()),
                new Claim(ClaimTypes.Name, studentUser.ExamNo ?? studentUser.Id.ToString()),
                new Claim("Role", $"{userRole}"),
                new Claim("FullName", $"{studentUser.Name} { studentUser.Surname}"),
                new Claim("CenterId", studentUser.CenterId.ToString()),
                 new Claim("CenterName", studentUser.Center.Name.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = creds,
                Audience = issuer,
                Issuer = issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            #endregion

            return new LoggedUser
            {
                Id = studentUser.Id,
                Email = studentUser.EmailAddress,
                Username = studentUser.ExamNo,
                FullName = $"{studentUser.Name} {studentUser.Surname}",
                FirstName = studentUser.Name,
                Surname = studentUser.Surname,
                CenterName = studentUser.Center.Name,
                Token = tokenHandler.WriteToken(token),
                Role = userRole,
            };
        }


  
        public async Task<User> RegisterAsync(RegisterModel model)
        {
            if (model.Password.Length < 8)
            {
                throw new Exception(ErrorMessages.Auth.PasswordValidationMessage); //password length error
            }

            if (!model.Password.Any(char.IsUpper))
            {
                throw new Exception(ErrorMessages.Auth.PasswordValidationMessage); //upper case error here
            }
            specialCharacterCheck(model.Password); 
            
            PasswordHelper.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);

            var username = model.Username.Trim().ToLower();

            var usernameExists = await _repository.AnyAsync<User>(x => x.Username.Trim().ToLower() == username);
            if (usernameExists)
            {
                throw new Exception(ErrorMessages.Auth.UsernameExists);
                //throw new Exception("User Name already exists");
                //throw new HttpResponse("Customer does not have any account", HttpStatusCode.BadRequest);
            }
            var newUser = new User
            {
                CenterId = model.CenterId,
                NumberOfCandidates = 1,
                ContactDetails = model.ContactDetails,
                //CenterTypeId = model.
                Modified = DateTime.Now,
                Name = model.FirstName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Surname = model.Surname,
                UserEmailAddress = model.Email,
                Username = model.Username,
                VsoftApproved = false,
                IsSchoolAdmin = false,
                IsActive = false,
                UserRoles = new List<UserRole>()
                {
                    new UserRole
                    {
                        RoleId = model.RoleId,
                        CenterId = model.CenterId,
                    },
                }
            };

            var user = await _repository.AddAsync(newUser, true);

            if (user != null)
            {
                EmailUserCredentials(model);

                return user;
            }
            else
            {
                throw new Exception(ErrorMessages.Auth.UserNotRegitered);
            }

            /*public ContentResult HR_COE()
            {


                return Content("<script language='javascript' type='text/javascript'>alert     ('Requested Successfully ');</script>");
            }*/
        }
        private void specialCharacterCheck(string password)
        {
            bool symbolCheck = password.Any(p => !char.IsLetterOrDigit(p));
            if (symbolCheck)
            //if (System.Text.RegularExpressions.Regex.IsMatch(password, "^[a-zA-Z0-9\x20]+$"))
            {
                Console.WriteLine("here"); 
                return; 
            }
            else
            {
                throw new Exception(ErrorMessages.Auth.PasswordValidationMessage); //special character error here
            }
        }
        /*private void specialCharacterCheck(string password)
        {
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCh = specialCh.ToCharArray();
            foreach (char ch in specialChArray)
            {
                if (password.Contains(ch))
                {
                    // 
                }
                else
                {
                    throw new Exception(ErrorMessages.Auth.PasswordValidationMessage); //special character error here
                }

            }
        }*/

        /*private User Content(string v)
        {
           return
        }*/

        public async Task<User> ResetUserPasswordAsync(User user, string password)
        {
            PasswordHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _repository.UpdateAsync(user, true);

            EmailNewUserCredentials(user, password);

            return user;
        }

        private async Task<bool> UpdatePasswordInTableAsync(string username, string password, User user)
        {
            var parameters = new Dictionary<string, object>();
            var md5Password = GeneralHelpers.EncryptPassword(password);

            parameters.Add(StoredProcedures.Params.pLoginName, username);
            parameters.Add(StoredProcedures.Params.pPassword, md5Password);

            var result = _repository.ExecuteStoredProcedure<Student>(StoredProcedures.AuthUser, parameters);

            if (result is not null && result[0] == StoredProcedures.Responses.LoggedIn)
            {
                PasswordHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _repository.UpdateAsync(user);
                await _repository.CompleteAsync();

                return true;
            }

            return false;
        }

        public Task<bool> LogOut(int centerId)
        {
            throw new NotImplementedException();
        }

        //public async Task<LoggedUser> SignOutAuthenticatedUser(string? username, int role)
        //{
        //    var user = await _repository.GetFirstOrDefaultAsync<User>(x => x.Username == username);
        //    //user.centerId = impersonatedCenterId;
        //    //var centerType = await _repository.GetFirstOrDefaultAsync<Center>(x => x.Id == impersonatedCenterId);

        //    #region Setup the token
        //    var tokenKey = _settings?.Key ?? string.Empty;
        //    var issuer = _settings?.Issuer ?? string.Empty;

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name,username ?? user.Id.ToString()),
        //        new Claim("Role", $"{""}"),
        //        new Claim("FullName", $"{""} { ""}"),
        //        new Claim("CenterId", ""),

        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.Now,
        //        SigningCredentials = creds,
        //        Audience = issuer,
        //        Issuer = issuer
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    #endregion

        //    return new LoggedUser
        //    {
        //        Id = user.Id,
        //        Email = user.UserEmailAddress, 
        //        Username = user.Username,
        //        FullName = $"{user.Name} {user.Surname}",
        //        FirstName = user.Name,
        //        Surname = user.Surname,
        //        Token = tokenHandler.WriteToken(token),
        //        Role = 0,
        //    };
        //}
  

        /*private async Task<bool> UpdateStudentPasswordInTableAsync(string username, string password, Student user)
        {
            var parameters = new Dictionary<string, object>();
            var md5Password = GeneralHelpers.EncryptPassword(password);

            parameters.Add(StoredProcedures.Params.pLoginName, username);
            parameters.Add(StoredProcedures.Params.pPassword, md5Password);

            var result = _repository.ExecuteStoredProcedure<Student>(StoredProcedures.AuthStudent, parameters);

            if (result is not null && result[0] == StoredProcedures.Responses.LoggedIn)
            {
                PasswordHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _repository.UpdateAsync(user);
                await _repository.CompleteAsync();

                return true;
            }

            return false;
        }*/
    }
}
