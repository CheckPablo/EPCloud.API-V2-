namespace ExamPortalApp.Contracts.Data.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}