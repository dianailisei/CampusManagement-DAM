using System;

namespace UCM.Business.Stage.Models
{
    public class StageDetailsModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartDate { get;  set; }
        public DateTimeOffset EndDate { get;  set; }
        public DateTimeOffset PostedDate { get; set; }
        public string Details { get;  set; }
    }
}
