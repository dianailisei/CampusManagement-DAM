using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain
{
    public class Role : Entity
    {
        public string Name { get; private set; }

        public ICollection<PersonRole> PersonRoles { get; set; } = new Collection<PersonRole>();

        public static Role Create(string name) => new Role() { Name = name };
    }
}
