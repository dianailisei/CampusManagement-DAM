using UCM.Business.Person.Models;

namespace UCM.Business.Student.Models
{
    public class StudentCreateModel : PersonCreateModel
    {
        public short Year { get; set; }

        public string Cnp { get; set; }
        public string Nationality { get; set; }

        public double Score { get; set; } = 0;
        public double SecondScore { get; set; } = 0;
    }
}
