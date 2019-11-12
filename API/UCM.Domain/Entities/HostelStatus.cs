using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain.Entities
{
    public class HostelStatus : Entity
    {
        public Guid HostelId { get; private set; }
        public Hostel Hostel { get; private set; }

        public int MaleSeats { get; private set; }
        public int OccupiedMaleSeats { get; private set; }
        public int ReservedMaleSeats { get; private set; }

        public int FemaleSeats { get; private set; }
        public int OccupiedFemaleSeats { get; private set; }
        public int ReservedFemaleSeats { get; private set; }


        public ICollection<StudentsGroup> StudentsGroups { get; private set; } = new Collection<StudentsGroup>();

        public DateTimeOffset CreatedDateTime { get; private set; } = DateTimeOffset.Now;
    }
}
