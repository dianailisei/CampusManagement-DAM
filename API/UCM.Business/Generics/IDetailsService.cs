using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UCM.Business.Generics
{
    public interface IDetailsService<TEntityDetails> where TEntityDetails : class
    {
        Task<TEntityDetails> GetAsync(Guid id, params string[] includes);
        Task<IEnumerable<TEntityDetails>> GetAllAsync(params string[] includes);
    }
}
