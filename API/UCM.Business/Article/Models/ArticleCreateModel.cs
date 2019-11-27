using System;

namespace UCM.Business.Article.Models
{
    public class ArticleCreateModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public Guid AdminId { get; set; }
    }
}
