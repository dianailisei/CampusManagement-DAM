using UCM.Business.Article.Models;
using FluentValidation;

namespace UCM.Business.Article.Validations
{
    public class ArticleCreateModelValidator : AbstractValidator<ArticleCreateModel>
    {
        public ArticleCreateModelValidator()
        {
            RuleFor(s => s.AdminId).NotEmpty();
            RuleFor(s => s.Title).NotEmpty().MinimumLength(5);
            RuleFor(s => s.Content).NotEmpty().MinimumLength(10);
        }
    }
}
