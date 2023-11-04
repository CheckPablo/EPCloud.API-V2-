using ExamPortalApp.Contracts.Data.Entities;
using System.Linq.Expressions;

namespace ExamPortalApp.Contracts.Data.Repositories.Generic
{
    public interface IRepository
    {
        Task<T> AddAsync<T>(T entity, bool save = false) where T : EntityBase;
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
        Task DeleteAsync<T>(int id, bool save = false) where T : EntityBase;
        Task<IEnumerable<T>> GetAllAsync<T>(params Expression<Func<T, object>>[] includes) where T : EntityBase;
        Task<T?> GetByIdAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : EntityBase;
        Task<T?> GetFirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
        Task<T?> GetFirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : EntityBase;
        Task<IEnumerable<T>> GetWhereAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
        Task<IEnumerable<T>> GetWhereAsync<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : EntityBase;
        Task<T> UpdateAsync<T>(T entity, bool save = false) where T : EntityBase;
        Task<int> CompleteAsync();
        IList<string>? ExecuteStoredProcedure<T>(string storedProcedureName, Dictionary<string, object> parameters);
        Task<List<TResult>> ExecuteStoredProcedureAsync<TResult>(string storedProcedureName, Dictionary<string, object> parameters) where TResult : class;
        Task<IEnumerable<TResult>> ExecuteStoredProcAsync<TResult>(string storedProcedureName, Dictionary<string, object> parameters) where TResult : class;
        IQueryable<T> GetQueryable<T>(params Expression<Func<T, object>>[] includes) where T : EntityBase;
    }
}
