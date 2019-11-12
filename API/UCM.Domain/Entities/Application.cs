using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain.Entities
{
    public class Application : Entity
    {
        public bool ChildOfTeacher { get; private set; }

        public string SpecialCases { get; private set; }
        public bool AccommodationRequest { get; private set; }
        public bool Scholarship { get; private set; }
        public string LastYearLocation { get; private set; }

        public ICollection<HostelPreference> HostelPreferences { get; private set; } = new Collection<HostelPreference>();
        public DateTimeOffset PostedDateTime { get; private set; } = DateTimeOffset.Now;

        public Guid StudentId { get; private set; }
        public Student Student { get; private set; }

        public void SetApplicationForHostelPreferences(Guid applicationId)
        {
            for (int i = 0; i < HostelPreferences.Count; ++i)
            {
                HostelPreferences.ElementAt(i).ApplicationId = applicationId;
            }
        }

        public static Application Create(Student student, bool childOfTeacher, string specialCases,
            bool accommodationRequest, bool scholarship, string lastYearLocation)
            => new Application()
            {
                StudentId = student.Id,
                Student = student,
                ChildOfTeacher = childOfTeacher,
                SpecialCases = specialCases,
                AccommodationRequest = accommodationRequest,
                Scholarship = scholarship,
                LastYearLocation = lastYearLocation
            };
    }
}
