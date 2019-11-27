using UCM.Business.Article.Models;
using UCM.Business.Generics;

namespace UCM.Business.Article
{
    public interface IArticleService :
        IDetailsService<ArticleDetailsModel>,
        ICreateService<ArticleCreateModel>
    {
    }
}
