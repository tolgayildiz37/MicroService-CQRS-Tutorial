using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tutorial.Orders.Domain.Entities.Base;

namespace Tutorial.Orders.Domain.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T,bool>> predicate);
        // disableTracking --> çekilen nesneleri editlemek istemediğimizde performans kazanmak için iptal edilir
        // includeString --> Lazy loading yaparken 1:N şeklinde olan foreign key dataları okumak için
        Task<IEnumerable<T>> GetAsync(Expression<Func<T,bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
