using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tutorial.Sourcing.Entities.Interfaces;

namespace Tutorial.Sourcing.Repositories.Interfaces
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
