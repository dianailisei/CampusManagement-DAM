using System;
using System.Collections.Generic;
using System.Linq;

namespace UCM.Business.Application.Models
{
    public class ApplicationDetailsModel
    {
        public Guid Id { get; set; }

        public bool ChildOfTeacher { get; set; }

        public string SpecialCases { get; set; }
        public bool AccommodationRequest { get; set; }
        public bool Scholarship { get; set; }
        public string LastYearLocation { get; set; }

        public List<HostelPreferenceDetailsModel> HostelPreferences { get; set; }
        public DateTimeOffset PostedDateTime { get; set; }

        public Guid StudentId { get; set; }
        public StudentDetailsModel Student { get; set; }

        public void HostelPreferencesSort()
        {
            HostelPreferences = HostelPreferences.OrderBy(o => o.PreferenceNumber).ToList();
        }
    }
}
