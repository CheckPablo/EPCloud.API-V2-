using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class CenterTypeRespository : ICenterTypeRespository
    {
        private readonly IRepository _repository;

        public CenterTypeRespository(IRepository repository)
        {
            _repository = repository;
        }

        public Task<CenterType> AddAsync(CenterType entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CenterType>> GetAllAsync()
        {
            var centerTypes = await _repository.GetAllAsync<CenterType>();

            return centerTypes.OrderBy(x => x.Description);
        }

        public Task<CenterType> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CenterType> UpdateAsync(CenterType entity)
        {
            throw new NotImplementedException();
        }
    }
}
