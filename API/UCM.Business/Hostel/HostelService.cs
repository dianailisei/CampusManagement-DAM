using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UCM.Business.Generics;
using UCM.Business.Hostel.Models;

namespace UCM.Business.Hostel
{
    public class HostelService : IHostelService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        private readonly DetailsService<Domain.Entities.Hostel, HostelDetailsModel> _detailsService;
        private readonly CreateService<Domain.Entities.Hostel, HostelCreateModel> _createService;

        public HostelService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;

            _detailsService = new DetailsService<Domain.Entities.Hostel, HostelDetailsModel>
                (genericRepository, mapper);
            _createService = new CreateService<Domain.Entities.Hostel, HostelCreateModel>
                (genericRepository, mapper);
        }

        public async Task<HostelDetailsModel> GetAsync(Guid id, params string[] includes)
        {
            return await _detailsService.GetAsync(id, includes);
        }

        public async Task<IEnumerable<HostelDetailsModel>> GetAllAsync(params string[] includes)
        {
            return await _detailsService.GetAllAsync(includes);
        }

        public async Task<Guid> AddAsync(HostelCreateModel entity)
        {
            return await _createService.AddAsync(entity);
        }

        public async Task<IEnumerable<Guid>> AddAsync(IEnumerable<HostelCreateModel> entities)
        {
            return await _createService.AddAsync(entities);
        }

        public async Task<Guid> UpdateAsync(Guid id, HostelCreateModel entity, params string[] includes)
        {
            return await _createService.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _createService.DeleteAsync(id);
        }

        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            await _createService.DeleteAsync(ids);
        }
    }
}
