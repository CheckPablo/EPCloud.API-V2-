using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using static SkiaSharp.HarfBuzz.SKShaper;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;
        private List<User> data;


        public UserManagementRepository(IRepository repository, IHttpContextAccessor accessor, IAuthRepository authRepository)
        {
            _repository = repository;
            _user = accessor.GetLoggedInUser();
            _authRepository = authRepository;
        }

        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<User>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            if (_user is null) return new List<User>();

            if (_user.RoleId == 1)
            {
                var users = await _repository.GetAllAsync<User>(x => x.Center);

                return users.OrderBy(x => x.Name).ThenBy(x => x.Surname);
            }
            else
            {
                return await GetUsersByCenterAsync(_user.CenterId);
            }
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _repository.GetByIdAsync<User>(id, x => x.Center.CenterType, x => x.CenterType);

            if (user == null) throw new EntityNotFoundException<User>(id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByCenterAsync(int? centerId)
        {
            if (centerId is null && _user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

            var id = centerId ?? _user?.CenterId ?? 0;
            var users = await _repository.GetWhereAsync<User>(x => x.CenterId == id, x => x.Center);

            return users.OrderBy(x => x.Name).ThenBy(x => x.Surname);
        }

        public async Task<User> ResetPasswordAsync(PasswordResetter resetter)
        {
            var user = await GetAsync(resetter.Id);

            return await _authRepository.ResetUserPasswordAsync(user, resetter.Password);
        }

        public async Task<IEnumerable<UserCenter>> SearchAsync(string activeState , string approvedState)
        {

            var users = _repository.GetQueryable<User>();
            //Center? center; 
            //if (activeState == "active") users = users.Where(x => x.IsActive == true);
            //if (activeState == "notactive") users = users.Where(x => x.IsActive == false);
            //if (approvedState == "approved") users = users.Where(x => x.VsoftApproved == true);
            //if (approvedState == "notapproved") users = users.Where(x => x.VsoftApproved == false);
            //if (_user is not null && _user.CenterId != 2) users = users.Where(x => x.CenterId == _user.CenterId);

            var parameters = new Dictionary<string, object>();

            if(activeState =="undefined")
            {activeState = "all"; }
            if (approvedState == "undefined")
            {approvedState = "all";}

            parameters.Add(StoredProcedures.Params.approve, approvedState);
            parameters.Add(StoredProcedures.Params.active, activeState);
            parameters.Add(StoredProcedures.Params.CenterID, _user.CenterId);
            var result = _repository.ExecuteStoredProcAsync<UserCenter>(StoredProcedures.UserApprovalState, parameters);
            return result.Result; 

        }
       
        private async Task SendApprovalEmailAsync(User user)
        {
            if (user.UserEmailAddress is null) return;

            #region Mail Message
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("qiscmapp@gmail.com");
            mail.To.Add(user.UserEmailAddress);
            mail.Bcc.Add("Tinashe@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = " Login Details for Exam Portal Cloud";

            mail.Body = "Dear User,\n \n"
            + " Welcome to Exam Portal Cloud, your account has been approved! You can now use your registration details received earlier to log in.\n \n"
            + " Use the following link to login : https://examportalcloud.co.za/ . \n \n "
            + " Thank you for your support. \n";
            #endregion

            #region Smtp Client
            SmtpClient smtpServer = new SmtpClient();

            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");
            smtpServer.Timeout = 20000;
            #endregion

            try
            {
                await smtpServer.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var user = await _repository.GetByIdAsync<User>(entity.Id);

            if (user == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                user.Username = entity.Username;
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.UserEmailAddress = entity.UserEmailAddress;
                user.ContactDetails = entity.ContactDetails;
                user.NumberOfCandidates = entity.NumberOfCandidates;
                //user.CenterId = entity.CenterId;    
                //user.CenterTypeId = entity.CenterTypeId;
                return await _repository.UpdateAsync(user, true);
            }
            //throw new NotImplementedException();
        }

        public async Task UpdateUsersAsync(BulkUserUpdate bulkUserUpdate)
        {
            var users = await _repository.GetWhereAsync<User>(x => bulkUserUpdate.UserIds.Contains(x.Id));

            foreach (var user in users)
            {
                var isApprovedChanged = (user.VsoftApproved == false && bulkUserUpdate.ApprovedUserIds.Any(x => x == user.Id));

                user.VsoftApproved = bulkUserUpdate.ApprovedUserIds.Any(x => x == user.Id);
                user.IsActive = bulkUserUpdate.ActiveUserIds.Any(x => x == user.Id);
                user.IsSchoolAdmin = bulkUserUpdate.AdminUserIds.Any(x => x == user.Id);

                if (isApprovedChanged == true)
                {
                    await SendApprovalEmailAsync(user);
                }
                await _repository.UpdateAsync(user);
            }

            await _repository.CompleteAsync();
        }
    }
}
