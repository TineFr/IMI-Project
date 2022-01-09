using FluentValidation;
using Imi.Project.Mobile.Core.Models;
using System;

namespace Imi.Project.Mobile.Validators
{
    public class BirdRequestModelValidator : AbstractValidator<BirdRequestModel>
    {

        public BirdRequestModelValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                .MaximumLength(25)
                .WithMessage("Name cannot be longer than 25 characters");

            RuleFor(model => model.HatchDate)
                .NotNull()
                .WithMessage("Hatchdate is required")
                .LessThanOrEqualTo(b => DateTime.Now.Date)
                .WithMessage("Hatch Date cannot be a future date");

            RuleFor(model => model.Gender)
                .NotNull()
                .WithMessage("Gender is required");

            RuleFor(model => model.Food)
                .MaximumLength(25)
                .WithMessage("Food cannot be longer than 25 characters")
                .When(model => model.Food != null);

        }
    }
}

