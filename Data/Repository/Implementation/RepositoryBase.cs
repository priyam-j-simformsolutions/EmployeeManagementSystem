using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable
        where T : class
    {
        protected RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// DbContext
        /// </summary>
        private DbContext context { get; }

        /// <summary>
        /// Get single entity by expression.
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>single entity.</returns>
        public async Task<T> GetSingleByIdAsync(Expression<Func<T, bool>> expression)
        {
            var getAll = await this.GetAllAsync();
            return await getAll.Where(expression).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all records of entity.
        /// </summary>
        /// <returns>all records of entity.</returns>
        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            IQueryable<T> query = this.context.Set<T>();
            return query;
        }

        /// <summary>
        /// Record count of given expression.
        /// </summary>
        /// <param name="expression">expression.</param>
        /// <returns>Count of filtered records.</returns>
        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> expression)
        {
            var query = await this.FindByAsync(expression);
            return await query.CountAsync();
        }

        /// <summary>
        /// Get filterd data based on expression. 
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>filterd data</returns>
        public async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = this.context.Set<T>().Where(expression);
            return query;
        }

        /// <summary>
        /// Add/Insert entity.
        /// </summary>
        /// <param name="entity">entity object</param>
        public virtual async Task AddAsync(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Update/modify entity.
        /// </summary>
        /// <param name="entity">entity object.</param>
        public virtual async Task UpdateAsync(T entity)
        {
            this.context.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete/Remove entity.
        /// </summary>
        /// <param name="entity">entity object.</param>
        public virtual async Task DeleteAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Delete/Remove records by expression 
        /// </summary>
        /// <param name="expression">expression.</param>
        public virtual async Task DeleteByAsync(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> entities = await FindByAsync(expression);
            this.context.Set<T>().RemoveRange(entities);
        }

        /// <summary>
        /// Check any record exist or not.
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>boolean.</returns>
        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            var query = await this.FindByAsync(expression);
            return await query.AnyAsync();
        }


        /// <summary>
        /// Exicute stored procedure with given parameter
        /// </summary>
        /// <typeparam name="TEntity">type of return object.</typeparam>
        /// <param name="sql">row sql.</param>
        /// <param name="parameters">list of parameters.</param>
        /// <returns>List of data with type"TEntity".</returns>
        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedureListAsync<TEntity>(string sql, params object[] parameters)
            where TEntity : class
            => await this.context.Set<TEntity>().FromSqlRaw(sql, parameters).ToListAsync();


        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
