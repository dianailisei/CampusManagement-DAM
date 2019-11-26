using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCM.Domain.Entities;

namespace UCM.Business.Generics
{
    public class DetailsService<TEntity, TEntityDetails> : IDetailsService<TEntityDetails>
        where TEntity : Entity
        where TEntityDetails : class
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public DetailsService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<TEntityDetails> GetAsync(Guid id, params string[] includes)
        {
            var result = await _genericRepository.GetAsync<TEntity>(id, includes);
            return _mapper.Map<TEntityDetails>(result);
        }

        public async Task<IEnumerable<TEntityDetails>> GetAllAsync(params string[] includes)
        {
            var result = await _genericRepository.GetAllAsync<TEntity>(includes);
            return _mapper.Map<IEnumerable<TEntityDetails>>(result);
        }
    }
}
