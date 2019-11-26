using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UCM.Domain.Entities
{
    public class Admin : Entity
    {
        public Guid PersonId { get; private set; }
        public Person Person { get; private set; }

        public ICollection<Article> Articles { get; private set; } = new Collection<Article>();

        public static Admin Create(Person person)
        {
            var admin = new Admin
            {
                Person = person,
                PersonId = person.Id
            };

            return admin;
        }
    }
}
