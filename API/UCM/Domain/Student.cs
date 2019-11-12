using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.Domain
{
    public class Student : Entity
    {
        public short Year { get; private set; }

        public double Score { get; private set; } = 0;
        public double SecondScore { get; private set; } = 0;

        public string Cnp { get; private set; }
        public string Nationality { get; private set; }

        public Guid PersonId { get; private set; }
        public Person Person { get; private set; }

        public Guid? StudentsGroupId { get; private set; }
        public StudentsGroup StudentsGroup { get; private set; }

        public bool Confirmed { get; private set; } = false;

        public static Student Create(Person person, short year, string cnp, string nationality, double score, double secondScore)
        {
            var student = new Student
            {
                Person = person,
                PersonId = person.Id,
                Year = year,
                Cnp = cnp,
                Nationality = nationality,
                Score = score,
                SecondScore = secondScore
            };

            return student;
        }

        public void Update(short year, string cnp, string nationality, double score, double secondScore,
            Guid studentsGroupId, bool confirmed)
        {
            Year = year;
            Cnp = cnp;
            Nationality = nationality;
            Score = score;
            SecondScore = secondScore;
            StudentsGroupId = studentsGroupId;
            Confirmed = confirmed;
        }

        public void Confirmation(bool confirmed, Guid studentsGroupId)
        {
            Confirmed = confirmed;
            if (studentsGroupId == Guid.Empty)
                StudentsGroupId = null;
            else
                StudentsGroupId = studentsGroupId;
        }

    }
}
