using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contract
{
    public interface IRepositoryBase<T>
        where T : class
    {
        Task<T> GetSingleByIdAsync(Expression<Func<T, bool>> expression);

        Task<IQueryable<T>> GetAllAsync();

        Task<int> GetCountAsync(Expression<Func<T, bool>> expression);

        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression);


        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteByAsync(Expression<Func<T, bool>> expression);


        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedureListAsync<TEntity>(string sql, params object[] parameters)
            where TEntity : class;
    }
}
