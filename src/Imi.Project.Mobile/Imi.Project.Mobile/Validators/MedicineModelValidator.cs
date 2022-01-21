using FluentValidation;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Validators
{
    public class MedicineModelValidator : AbstractValidator<MedicineModel>
    {
        public MedicineModelValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                .MaximumLength(25)
                .WithMessage("Name cannot be longer than 25 characters");

            RuleFor(model => model.Usage)
                .NotEmpty()
                .WithMessage("Usage is required");
        }
    }
}
