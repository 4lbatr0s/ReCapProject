using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>>  filter);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
