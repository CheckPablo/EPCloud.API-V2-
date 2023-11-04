using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly IRepository _repository;

        public ProvinceRepository(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Province> AddAsync(Province entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Province>> GetAllAsync()
        {
            var provinces = await _repository.GetAllAsync<Province>();

            return provinces.OrderBy(x => x.Name);
        }

        public Task<Province> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Province> UpdateAsync(Province entity)
        {
            throw new NotImplementedException();
        }
    }
}
