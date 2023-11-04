using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Exceptions;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class TestTypeRepository : ITestTypeRepository
    {
        private readonly IRepository _repository;
        public TestTypeRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TestType> AddAsync(TestType entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<TestType>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<TestType>> GetAllAsync()
        {
            return await _repository.GetAllAsync<TestType>();   
        }

        public async Task<TestType> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<TestType>(id);

            if (entity == null) throw new EntityNotFoundException<TestType>(id);

            return entity;
        }

        public async Task<TestType> UpdateAsync(TestType entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }
    }
}
