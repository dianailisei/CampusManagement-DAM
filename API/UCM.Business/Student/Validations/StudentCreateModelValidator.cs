using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UCM.Business.Person.Validations;
using UCM.Business.Student.Models;

namespace UCM.Business.Student.Validations
{
    public class StudentCreateModelValidator : AbstractValidator<StudentCreateModel>
    {
        public StudentCreateModelValidator()
        {
            RuleFor(s => s).SetValidator(new PersonCreateModelValidator());
            RuleFor(s => s.Year).InclusiveBetween((short)1, (short)5);
        }
    }
}
