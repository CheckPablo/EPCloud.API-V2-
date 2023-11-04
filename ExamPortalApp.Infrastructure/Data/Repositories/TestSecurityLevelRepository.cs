using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Exceptions;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class TestSecurityLevelRepository : ITestSecurityLevelRepository
    {
        private readonly IRepository _repository;
        public TestSecurityLevelRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TestSecurityLevel> AddAsync(TestSecurityLevel entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<TestSecurityLevel>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<TestSecurityLevel>> GetAllAsync()
        {
            return await _repository.GetAllAsync<TestSecurityLevel>();   
        }

        public async Task<TestSecurityLevel> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<TestSecurityLevel>(id);

            if (entity == null) throw new EntityNotFoundException<TestSecurityLevel>(id);

            return entity;
        }

        public async Task<TestSecurityLevel> UpdateAsync(TestSecurityLevel entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }
    }
}
