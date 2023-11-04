using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Exceptions;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly IRepository _repository;
        public LanguageRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Language> AddAsync(Language entity)
        {
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<Language>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _repository.GetAllAsync<Language>();   
        }

        public async Task<Language> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<Language>(id);

            if (entity == null) throw new EntityNotFoundException<Language>(id);

            return entity;
        }

        public async Task<Language> UpdateAsync(Language entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }
    }
}
