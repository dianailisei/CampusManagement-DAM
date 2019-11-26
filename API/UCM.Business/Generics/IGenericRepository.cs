using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UCM.Domain.Entities;

namespace UCM.Business.Generics
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(Guid id, params string[] includes) where T : Entity;
        Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : Entity;
        Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, params string[] includes) where T : Entity;
        Task<Guid> AddAsync<T>(T entity) where T : Entity;
        Task<IEnumerable<Guid>> AddAsync<T>(IEnumerable<T> entites) where T : Entity;
        Task<Guid> UpdateAsync<T>(T entity, params string[] includes) where T : Entity;
        Task DeleteAsync<T>(Guid id) where T : Entity;
        Task DeleteAsync<T>(IEnumerable<Guid> ids) where T : Entity;
        Task SaveAsync();
    }
}
