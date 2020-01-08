using System;
using System.Collections.Generic;
using System.Text;
using UCM.Business.Student.Models;

namespace UCM.Business.Student.Builder
{
    class StudentBuilder : IStudentBuilder
    {
        public StudentCreateModel StudentModel = new StudentCreateModel();

        public StudentCreateModel Build()
        {
            return StudentModel;
        }

        public void SetCnp(string value)
        {
            StudentModel.Cnp = value;
        }

        public void SetEmail(string value)
        {
            StudentModel.Email = value;
        }

        public void SetFirstName(string value)
        {
            StudentModel.FirstName = value;
        }

        public void SetGender(string value)
        {
            StudentModel.Gender = value;
        }

        public void SetLastName(string value)
        {
            StudentModel.LastName = value;
        }

        public void SetNationality(string value)
        {
            StudentModel.Nationality = value;
        }

        public void SetPassword(string value)
        {
            StudentModel.Password = value;
        }

        public void SetScore(double value)
        {
            StudentModel.Score = value;
        }

        public void SetSecondScore(double value)
        {
            StudentModel.SecondScore = value;
        }

        public void SetYear(int value)
        {
            StudentModel.Year = (short)value;
        }
    }
}
