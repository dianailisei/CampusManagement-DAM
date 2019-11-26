using System;
using System.Collections.Generic;

namespace UCM.Business.HostelStatus.Models
{
    public class HostelStatusCreateModel
    {
        public Guid HostelId { get; set; }

        public int MaleSeats { get; set; } = 0;
        public int ReservedMaleSeats { get; set; } = 0;

        public int FemaleSeats { get; set; } = 0;
        public int ReservedFemaleSeats { get; set; } = 0;

        public ICollection<StudentsGroupCreateModel> StudentsGroups { get; set; } = null;
    }
}
