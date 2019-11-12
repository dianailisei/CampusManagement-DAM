using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain.Entities
{
    public class Stage : Entity
    {
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset EndDate { get; private set; }
        public DateTimeOffset PostedDate { get; private set; } = DateTimeOffset.Now;
        public string Details { get; private set; }

        public static Stage Create(DateTimeOffset startDate, DateTimeOffset endDate, string details) => new Stage()
        {
            StartDate = startDate,
            EndDate = endDate,
            Details = details
        };
    }
}
