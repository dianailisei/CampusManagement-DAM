using System;

namespace UCM.Business.HostelStatus.Models
{
    public class StudentsGroupCreateModel
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Gender { get; set; }
        public int Year { get; set; }

        public int Seats { get; set; }
    }
}
