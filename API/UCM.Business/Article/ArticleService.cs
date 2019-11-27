using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UCM.Business.Article.Models;
using UCM.Business.Generics;

namespace UCM.Business.Article
{
    public class ArticleService : IArticleService
    {
        private readonly IGenericRepository _genericRepository;
        //private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        private readonly DetailsService<Domain.Entities.Article, ArticleDetailsModel> _detailsService;
        private readonly CreateService<Domain.Entities.Article, ArticleCreateModel> _createService;


        public ArticleService(IGenericRepository genericRepository, IMapper mapper)//, IPasswordHasher passwordHasher)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
           // _passwordHasher = passwordHasher;

            _detailsService = new DetailsService<Domain.Entities.Article, ArticleDetailsModel>
                (genericRepository, mapper);
            _createService = new CreateService<Domain.Entities.Article, ArticleCreateModel>
                (genericRepository, mapper);
        }

        public async Task<ArticleDetailsModel> GetAsync(Guid id, params string[] includes)
        {
            return await _detailsService.GetAsync(id, includes);
        }

        public async Task<IEnumerable<ArticleDetailsModel>> GetAllAsync(params string[] includes)
        {
            return await _detailsService.GetAllAsync(includes);
        }

        public async Task<Guid> AddAsync(ArticleCreateModel entity)
        {
            return await _createService.AddAsync(entity);
        }

        public async Task<IEnumerable<Guid>> AddAsync(IEnumerable<ArticleCreateModel> entities)
        {
            return await _createService.AddAsync(entities);
        }

        public async Task<Guid> UpdateAsync(Guid id, ArticleCreateModel entity, params string[] includes)
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
