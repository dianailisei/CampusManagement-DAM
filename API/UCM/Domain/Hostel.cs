using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain
{
    public class Hostel : Entity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string MapLocation { get; private set; }
        public int TotalCapacity { get; private set; }
        public string HostelAdminFullName { get; private set; }

        public static Hostel Create(string name, string address, string mapLocation,
            int totalCapacity, string hostelAdminFullName) => new Hostel()
            {
                Name = name,
                Address = address,
                MapLocation = mapLocation,
                TotalCapacity = totalCapacity,
                HostelAdminFullName = hostelAdminFullName
            };
    }
}
