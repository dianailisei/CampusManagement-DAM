using System;

namespace UCM.Business.Article.Models
{
    public class ArticleDetailsModel
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }

        public DateTimeOffset PostedDateTime { get; private set; }
        
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }
    }
}
