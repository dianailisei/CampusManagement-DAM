using System;
using UCM.Business.Hostel.Models;

namespace UCM.Business.Application.Models
{
    public class HostelPreferenceDetailsModel
    {
        public int PreferenceNumber { get; set; }

        public Guid HostelId { get; set; }
        public HostelDetailsModel Hostel { get; set; }
    }
}
