using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace ExamPortalApp.Infrastructure.Data.Repositories.Generic
{
    public class Repository : IRepository
    {
        private readonly ExamPortalDatabaseContext _dbContext;

        public Repository(ExamPortalDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add data to the database.
        /// </summary>
        /// <typeparam name="T">T = entity type</typeparam>
        /// <param name="entity">The data to be added to the database. Must extend EntityBase</param>
        /// <param name="save">Optional parameter to save immediately without another call to CompleteAsync()</param>
        /// <returns></returns>
        public async virtual Task<T> AddAsync<T>(T entity, bool save = false) where T : EntityBase
        {
            await _dbContext.Set<T>().AddAsync(entity);

            if (save) await CompleteAsync();

            return entity;
        }

        public async virtual Task<bool> AnyAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            return await _dbContext.Set<T>().AnyAsync(expression);
        }

        /// <summary>
        /// This method needs to be called to save data to the database after adding, updating or deleting
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async virtual Task<int> CountAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            return await _dbContext.Set<T>().CountAsync(expression);
        }

        /// <summary>
        /// Delete data from the database.
        /// </summary>
        /// <typeparam name="T">T = entity type</typeparam>
        /// <param name="entity">The data to be removed from the database. Must extend EntityBase</param>
        /// <param name="save">Optional parameter to save immediately without another call to CompleteAsync()</param>
        /// <returns></returns>
        public async virtual Task DeleteAsync<T>(int id, bool save = false) where T : EntityBase
        {
            var entry = await _dbContext.Set<T>().FindAsync(id);

            if (entry is not null)
            {
                entry.IsDeleted = true;
                _dbContext.Entry(entry).State = EntityState.Modified;

                if (save) await CompleteAsync();
            }
        }

        public IList<string>? ExecuteStoredProcedure<TResult>(string storedProcedureName, Dictionary<string, object> parameters)
        {
            var sqlParams = new List<SqlParameter>();
            var sqlBuilder = new StringBuilder($"EXEC {storedProcedureName}");

            foreach (var kvp in parameters)
            {
                sqlBuilder.Append($" @{kvp.Key},");

                var sqlParam = new SqlParameter($"@{kvp.Key}", kvp.Value ?? DBNull.Value);

                sqlParams.Add(sqlParam);
            }

            sqlBuilder.Length--;

            var sql = sqlBuilder.ToString();
            var result = _dbContext.Database.SqlQueryRaw<string>(sql, sqlParams.ToArray()).ToList();

            return result;
        }

        public async Task<List<TResult>> ExecuteStoredProcedureAsync<TResult>(string storedProcedureName, Dictionary<string, object> parameters) where TResult : class
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                foreach (var parameter in parameters)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = parameter.Key;
                    dbParameter.Value = parameter.Value;
                    var sqlParam = new SqlParameter($"@{parameter.Key}", parameter.Value ?? DBNull.Value);
                    command.Parameters.Add(dbParameter);
                }

                await _dbContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var resultList = new List<TResult>();

                    while (await result.ReadAsync())
                    {
                        var record = (IDataRecord)result;
                        var type = typeof(TResult);
                        var activator = Activator.CreateInstance(type);

                        if (activator is not null) {
                            var instance = (TResult)activator;

                            for (int i = 0; i < record.FieldCount; i++)
                            {
                                var fieldName = record.GetName(i);
                                //var fieldValue = record.GetValue(i);
                                var fieldValue = record.GetValue(i) == DBNull.Value ? null : record.GetValue(i);
                                type.GetProperty(fieldName)?.SetValue(instance, fieldValue);
                                type.GetProperty(fieldName)?.SetValue(instance, fieldValue);
                            }

                            resultList.Add(instance);
                        }
                    }

                    return resultList;
                }
            }
        }

        public async Task<IEnumerable<TResult>> ExecuteStoredProcAsync<TResult>(string storedProcedureName, Dictionary<string, object> parameters) where TResult : class
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                foreach (var parameter in parameters)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = parameter.Key;
                    dbParameter.Value = parameter.Value;
                    command.Parameters.Add(dbParameter);
                }

                await _dbContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var resultList = new List<TResult>();

                    while (await result.ReadAsync())
                    {
                        var record = (IDataRecord)result;
                        var type = typeof(TResult);
                        var activator = Activator.CreateInstance(type);

                        if (activator is not null)
                        {
                            var instance = (TResult)activator;

                            for (int i = 0; i < record.FieldCount; i++)
                            {
                                var fieldName = record.GetName(i);
                                //var fieldValue = record.GetValue(i);
                                var fieldValue = record.GetValue(i) == DBNull.Value ? null : record.GetValue(i);
                                type.GetProperty(fieldName)?.SetValue(instance, fieldValue);
                            }

                            resultList.Add(instance);
                        }
                    }

                    return resultList;
                }
            }
        }
        public async virtual Task<IEnumerable<T>> GetAllAsync<T>(params Expression<Func<T, object>>[] includes) where T : EntityBase
        {
            var query = _dbContext.Set<T>().Where(x => !x.IsDeleted).AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async virtual Task<T?> GetByIdAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : EntityBase
        {
            var query = _dbContext.Set<T>().Where(x => !x.IsDeleted).AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<T?> GetFirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            return await _dbContext.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(expression);
        }

        public async virtual Task<T?> GetFirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : EntityBase
        {
            var query = _dbContext.Set<T>().Where(x => !x.IsDeleted).AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public virtual IQueryable<T> GetQueryable<T>(params Expression<Func<T, object>>[] includes) where T : EntityBase
        {
            return _dbContext.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public async virtual Task<IEnumerable<T>> GetWhereAsync<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            return await _dbContext.Set<T>().Where(x => !x.IsDeleted).Where(expression).ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetWhereAsync<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : EntityBase
        {
            var query = _dbContext.Set<T>().Where(x => !x.IsDeleted).AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(expression).ToListAsync();
        }

        /// <summary>
        /// Update data in the database.
        /// </summary>
        /// <typeparam name="T">T = entity type</typeparam>
        /// <param name="entity">The data to be updated. Must extend EntityBase</param>
        /// <param name="save">Optional parameter to save immediately without another call to CompleteAsync()</param>
        /// <returns></returns>
        public async virtual Task<T> UpdateAsync<T>(T entity, bool save = false) where T : EntityBase
        {
            var entry = await _dbContext.Set<T>().FindAsync(entity.Id);

            if (entry is not null)
            {
                //entity.DateUpdated = DateTime.UtcNow;

                _dbContext.Entry(entry).State = EntityState.Detached;
                _dbContext.Entry(entity).State = EntityState.Modified;

                if (save) await CompleteAsync();
            }

            return entry;
        }
    }
}
