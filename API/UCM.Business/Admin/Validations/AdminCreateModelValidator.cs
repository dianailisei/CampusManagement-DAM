using UCM.Business.Admin.Models;
using UCM.Business.Person.Validations;
using FluentValidation;

namespace UCM.Business.Admin.Validations
{
    public class AdminCreateModelValidator : AbstractValidator<AdminCreateModel>
    {
        public AdminCreateModelValidator()
        {
            RuleFor(s => s).SetValidator(new PersonCreateModelValidator());
        }
    }
}
