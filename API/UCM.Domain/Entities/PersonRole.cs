using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain.Entities
{
    public class PersonRole : Entity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
