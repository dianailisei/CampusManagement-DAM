using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool Available { get; set; }
        public void Delete()
        {
            Available = false;
        }

        public void Initialize()
        {
            Id = Guid.NewGuid();
        }
    }
}
