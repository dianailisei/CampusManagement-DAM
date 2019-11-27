using System;
using System.Collections.Generic;

namespace UCM.Business.Application.Models
{
    public class ApplicationCreateModel
    {
        public Guid StudentId { get; set; }

        public bool ChildOfTeacher { get; set; }

        public string SpecialCases { get; set; }

        public bool Scholarship { get; set; }
        public bool AccommodationRequest { get; set; }

        public ICollection<HostelPreferenceCreateModel> HostelPreferences { get; set; }

        public string LastYearLocation { get; set; }
    }
}
