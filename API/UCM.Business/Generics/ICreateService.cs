using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UCM.Business.Generics
{
    public interface ICreateService<in TCreateEntity> where TCreateEntity : class
    {
        Task<Guid> AddAsync(TCreateEntity entity);
        Task<IEnumerable<Guid>> AddAsync(IEnumerable<TCreateEntity> entities);

        Task<Guid> UpdateAsync(Guid id, TCreateEntity entity, params string[] includes);

        Task DeleteAsync(Guid id);
        Task DeleteAsync(IEnumerable<Guid> ids);
    }
}

