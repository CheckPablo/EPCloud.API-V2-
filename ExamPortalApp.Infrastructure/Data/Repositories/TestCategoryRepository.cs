using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Exceptions;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class TestCategoryRepository : ITestCategoryRepository
    {
        private readonly IRepository _repository;
        public TestCategoryRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TestCategory> AddAsync(TestCategory entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<TestCategory>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<TestCategory>> GetAllAsync()
        {
            var centerToDisplay = await _repository.GetWhereAsync<TestCategory>(x => x.Id==3);
            return centerToDisplay;
            //return await _repository.GetAllAsync<TestCategory>();   
        }

        public async Task<TestCategory> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<TestCategory>(id);

            if (entity == null) throw new EntityNotFoundException<TestCategory>(id);

            return entity;
        }

        public async Task<TestCategory> UpdateAsync(TestCategory entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }
    }
}
