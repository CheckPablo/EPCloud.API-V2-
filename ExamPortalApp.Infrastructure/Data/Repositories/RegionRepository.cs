using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;

        public RegionRepository(IRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _user = accessor.GetLoggedInUser();
        }

        public async Task<Region> AddAsync(Region entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<Region>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            //return await _repository.GetAllAsync<Region>();
            if (_user == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
            var regions = await _repository.GetAllAsync<Region>();
            return regions.Distinct().OrderBy(x => x.Description).Where(x => x.IsDeleted == false); 
        }

        public async Task<Region> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<Region>(id);

            if (entity == null) throw new EntityNotFoundException<Region>(id);

            return entity;
        }

        public async Task<Region> UpdateAsync(Region entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }
    }
}
