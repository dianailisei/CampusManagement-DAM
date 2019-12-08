using System;
using System.Collections.Generic;
using UCM.Business.Student.Models;

namespace UCM.Business.HostelStatus.Models
{
    public class StudentsGroupDetailsModel
    {

        public Guid Id { get; set; }

        public string Gender { get;  set; }
        public int Year { get;  set; }

        public int Seats { get;  set; }

        public Guid HostelStatusId { get;  set; }

        public ICollection<StudentDetailsModel> Students { get;  set; }
    }
}
