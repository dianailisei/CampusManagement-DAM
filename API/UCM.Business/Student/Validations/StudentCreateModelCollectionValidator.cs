using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UCM.Business.Student.Models;

namespace UCM.Business.Student.Validations
{
    public class StudentCreateModelCollectionValidator : AbstractValidator<IEnumerable<StudentCreateModel>>
    {
        public StudentCreateModelCollectionValidator()
        {
            RuleForEach(m => m).SetValidator(new StudentCreateModelValidator());
        }
    }
}
