using UCM.Business.Admin.Models;
using UCM.Business.Admin.Validations;
using FluentValidation;
using System.Collections.Generic;

namespace UCM.Business.Admin.Validations
{
    public class AdminCreateModelCollectionValidator : AbstractValidator<IEnumerable<AdminCreateModel>>
    {
        public AdminCreateModelCollectionValidator()
        {
            RuleForEach(m => m).SetValidator(new AdminCreateModelValidator());
        }
    }
}
