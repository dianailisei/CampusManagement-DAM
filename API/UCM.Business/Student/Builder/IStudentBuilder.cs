using UCM.Business.Student.Models;

namespace UCM.Business.Student.Builder
{
    public interface IStudentBuilder
    {
        void SetFirstName(string value);
        void SetLastName(string value);
        void SetEmail(string value);
        void SetGender(string value);
        void SetPassword(string value);
        void SetYear(int value);
        void SetCnp(string value);
        void SetNationality(string value);
        void SetScore(double value);
        void SetSecondScore(double value);
        StudentCreateModel Build();
    }
}
