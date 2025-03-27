using SurisCodeTest.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories.Generic
{
    public interface IGenericRepository<T> where T : IEntity
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        Task<T?> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<T?> DeleteAsync(Guid id);

    }
}
