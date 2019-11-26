using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCM.Domain.Entities;

namespace UCM.Business.Generics
{
    public class CreateService<TEntity, TCreateEntity> : ICreateService<TCreateEntity>
    where TEntity : Entity
    where TCreateEntity : class
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public CreateService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }


        public async Task<Guid> AddAsync(TCreateEntity entity)
        {
            var entityData = _mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(entityData);
            await _genericRepository.SaveAsync();
            return entityData.Id;
        }

        public async Task<IEnumerable<Guid>> AddAsync(IEnumerable<TCreateEntity> entities)
        {
            var entitiesData = _mapper.Map<IEnumerable<TEntity>>(entities);
            var result = await _genericRepository.AddAsync(entitiesData);
            await _genericRepository.SaveAsync();
            return result;
        }

        public async Task<Guid> UpdateAsync(Guid id, TCreateEntity entity, params string[] includes)
        {
            var entityData = _mapper.Map<TEntity>(entity);
            entityData.Id = id;

            var result = await _genericRepository.UpdateAsync(entityData, includes);

            await _genericRepository.SaveAsync();
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync<TEntity>(id);
            await _genericRepository.SaveAsync();
        }

        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            await _genericRepository.DeleteAsync<TEntity>(ids);
            await _genericRepository.SaveAsync();
        }
    }
}

