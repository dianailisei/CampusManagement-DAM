using System;

namespace UCM.Business.HostelStatus.Models
{
    public class DateIntervalFilterModel
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
