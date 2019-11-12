using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain.Entities
{
    public class Article : Entity
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }

        public DateTimeOffset PostedDateTime { get; private set; } = DateTimeOffset.Now;

        public Guid AdminId { get; private set; }
        public Admin Admin { get; private set; }

        public static Article Create(Admin admin, string title, string content, string image) =>
            new Article()
            {
                Title = title,
                Content = content,
                Image = image,
                AdminId = admin.Id,
                Admin = admin
            };
    }
}
