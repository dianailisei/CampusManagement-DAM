using System;

namespace UCM.Business.Hostel.Models
{
    public class HostelDetailsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get;  set; }
        public string MapLocation { get;  set; }
        public int TotalCapacity { get;  set; }
        public string HostelAdminFullName { get;  set; }
    }
}
