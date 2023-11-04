using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IUserManagementRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetUsersByCenterAsync(int? centerId);
        Task UpdateUsersAsync(BulkUserUpdate bulkUserUpdate);
        Task<User> ResetPasswordAsync(PasswordResetter resetter);
        Task<User> UpdateAsync(User user);
        Task<IEnumerable<UserCenter>> SearchAsync(string activeState, string approvedState);
        //Task<IList<User>> SearchAsync(string activeState, string approvedState);
    }
}