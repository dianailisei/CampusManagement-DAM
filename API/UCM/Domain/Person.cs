using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain
{
    public class Person : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Gender { get; private set; }
        public string Password { get; private set; }

        public ICollection<PersonRole> PersonRoles { get; set; } = new Collection<PersonRole>();

        public static Person Create(string firstName, string lastName,
            string email, string gender, string password, IEnumerable<Guid> rolesGuid)
        {
            var person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Gender = gender,
                Password = password
            };

            foreach (var guid in rolesGuid)
            {
                person.PersonRoles.Add(new PersonRole { RoleId = guid });
            }

            return person;
        }
    }
}
