using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
   
    public class CenterRepository : ICenterRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;

        public CenterRepository(IRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _user = accessor.GetLoggedInUser();

        }

        public async Task<Center> AddAsync(Center entity)
        {
            //entity.CenterId = _user.CenterId;
            var centerExists = await _repository.AnyAsync<Center>(x => x.Name == entity.Name);
            if (centerExists)
            {
                throw new Exception(ErrorMessages.CenterEntryChecks.CenterExists);
            }
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<Center>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<Center>> GetAllAsync()
        {
            //return await _repository.GetAllAsync<Center>(x => x.Students);
            var centerRequest = await _repository.GetQueryable<Center>(x => x.Students)
                .Select(x => new Center
                             {
                                 AttendanceRegisterPassword = x.AttendanceRegisterPassword,
                                 CenterNo = x.CenterNo,
                                 CenterType = x.CenterType,
                                 CenterTypeId = x.CenterTypeId,
                                 Disclaimer = x.Disclaimer,
                                 ExpiryDate = x.ExpiryDate,
                                 Id = x.Id,
                                 //LicenceInfo=x.MaximumLicense,
                                 MaximumLicense = x.MaximumLicense,
                                 ModifiedBy = x.ModifiedBy,
                                 ModifiedDate = x.ModifiedDate,
                                 Name = x.Name,
                                 Prefix = x.Prefix,
                                 //Province,
                                ProvinceId =x.ProvinceId,
                                Removed = x.Removed,
                                }).ToListAsync();
            //return users.OrderBy(x => x.Name).ThenBy(x => x.Surname);
            return centerRequest.Distinct().OrderBy(x => x.Name).ThenBy(x => x.ExpiryDate);
            //return users.OrderBy.Distinct().OrderBy(x => x.Name).ThenBy(x => x.Surname); 
        }

        public async Task<Center> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<Center>(id);

            if (entity == null) throw new EntityNotFoundException<Center>(id);

            return entity;
        }
        public async Task<IEnumerable<Center>> GetCenterByUser()
        {
            //if (_user == null)
            //{
               // throw new Exception(ErrorMessages.Auth.Unauthorised);
            //}
            var centerToDisplay = await _repository.GetWhereAsync<Center>(x => x.Id == _user.CenterId);
            //return centerToDisplay.OrderBy(x => x.Name);
            return centerToDisplay; 
        }

        public async Task<IEnumerable<Center>> SearchCenterSummaryAsync()
        {     //
            var parameters = new Dictionary<string, object>
            {
            };
            var result = await _repository.ExecuteStoredProcAsync<Center>(StoredProcedures.Get_CenterSummary, parameters).ConfigureAwait(false);
            return result;
        }

    

        public async Task<Center> UpdateAsync(Center entity)
        {
            var center = await _repository.GetByIdAsync<Center>(entity.Id);

            if (center == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                center.CenterTypeId = entity.CenterTypeId;
                center.Prefix = entity.Prefix;
                center.Name = entity.Name;
                center.ExpiryDate = entity.ExpiryDate;
                center.ProvinceId = entity.ProvinceId;
                center.MaximumLicense = entity.MaximumLicense;
                center.CenterNo = entity.CenterNo;
                return await _repository.UpdateAsync(center, true);
            }
        }

        //Task ICenterRepository.GetCenterByUser()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
