using System;
using UCM.Business.Person.Models;

namespace UCM.Business.Student.Models
{
    public class StudentDetailsModel : PersonDetailsModel
    {
        public Guid Id { get; set; }
        public short Year { get; set; }

        public string Cnp { get; set; }
        public string Nationality { get; set; }

        public double Score { get; set; }
        public double SecondScore { get; set; }

        public Guid? StudentsGroupId { get; set; }
        public bool Confirmed { get; set; }
    }
}
