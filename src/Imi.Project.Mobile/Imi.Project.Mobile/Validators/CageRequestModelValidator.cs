using FluentValidation;
using Imi.Project.Mobile.Core.Models;

namespace Imi.Project.Mobile.Validators
{
    public class CageRequestModelValidator : AbstractValidator<CageRequestModel>
    {
        public CageRequestModelValidator()
        {
            RuleFor(model => model.Location)
                .NotEmpty()
                .WithMessage("Location cannot be empty")
                .MaximumLength(25)
                .WithMessage("Name cannot be longer than 25 characters");

            RuleFor(model => model.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                .MaximumLength(25)
                .WithMessage("Location cannot be longer than 25 characters");
        }
    }
}
