using FluentValidation;
using UCM.Business.Person.Models;

namespace UCM.Business.Person.Validations
{
    public class PersonCreateModelValidator : AbstractValidator<PersonCreateModel>
    {
        public PersonCreateModelValidator()
        {
            RuleFor(s => s.LastName).NotEmpty().Length(2, 20).Matches(@"^[\s\S-]+$");
            RuleFor(s => s.FirstName).NotEmpty().Length(2, 20).Matches(@"^[\s\S-]+$");
            RuleFor(s => s.Email).NotEmpty().EmailAddress().
                WithMessage(m => $"{m.FirstName} {m.LastName} has wrong Email format ({m.Email}).");
            RuleFor(s => s.Password).NotEmpty().MinimumLength(6);
        }
    }
}
