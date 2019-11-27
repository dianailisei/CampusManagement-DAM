using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UCM.Business.Generics;
using UCM.Business.Stage.Models;

namespace UCM.Business.Stage
{
    public class StageService : IStageService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        private readonly DetailsService<Domain.Entities.Stage, StageDetailsModel> _detailsService;
        private readonly CreateService<Domain.Entities.Stage, StageCreateModel> _createService;


        public StageService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;

            _detailsService = new DetailsService<Domain.Entities.Stage, StageDetailsModel>
                (genericRepository, mapper);
            _createService = new CreateService<Domain.Entities.Stage, StageCreateModel>
                (genericRepository, mapper);
        }

        public async Task<StageDetailsModel> GetAsync(Guid id, params string[] includes)
        {
            return await _detailsService.GetAsync(id, includes);
        }

        public async Task<IEnumerable<StageDetailsModel>> GetAllAsync(params string[] includes)
        {
            return await _detailsService.GetAllAsync(includes);
        }

        public async Task<Guid> AddAsync(StageCreateModel entity)
        {
            var students = await _genericRepository.FindAsync<Domain.Entities.Student>(s => s.StudentsGroupId != null && s.Confirmed == false);

            foreach (var student in students)
            {
                student.Confirmation(false, Guid.Empty);
                await _genericRepository.UpdateAsync(student);
            }

            await _genericRepository.SaveAsync();

            return await _createService.AddAsync(entity);
        }

        public async Task<IEnumerable<Guid>> AddAsync(IEnumerable<StageCreateModel> entities)
        {


            return await _createService.AddAsync(entities);
        }

        public async Task<Guid> UpdateAsync(Guid id, StageCreateModel entity, params string[] includes)
        {
            return await _createService.UpdateAsync(id, entity, includes);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _createService.DeleteAsync(id);
        }

        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            await _createService.DeleteAsync(ids);
        }

        public async Task<StageDetailsModel> GetLastStage(params string[] includes)
        {
            var stages = await _detailsService.GetAllAsync();
            var result = stages.OrderByDescending(s => s.PostedDate).FirstOrDefault();
            return result;
        }
    }
}
