using System;
using System.Collections.Generic;
using UCM.Business.Hostel.Models;

namespace UCM.Business.HostelStatus.Models
{
    public class HostelStatusDetailsModel
    {
        public Guid Id { get; private set; }

        public Guid HostelId { get; private set; }
        public HostelDetailsModel Hostel { get; private set; }

        public int MaleSeats { get; private set; }
        public int OccupiedMaleSeats { get; private set; }
        public int ReservedMaleSeats { get; private set; }

        public int FemaleSeats { get; private set; }
        public int OccupiedFemaleSeats { get; private set; }
        public int ReservedFemaleSeats { get; private set; }


        public ICollection<StudentsGroupDetailsModel> StudentsGroups { get; private set; }

        public DateTimeOffset CreatedDateTime { get; private set; }
    }
}
