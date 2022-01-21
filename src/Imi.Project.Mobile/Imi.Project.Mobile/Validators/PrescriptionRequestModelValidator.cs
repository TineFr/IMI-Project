using FluentValidation;
using Imi.Project.Mobile.Core.Models;
using System;

namespace Imi.Project.Mobile.Validators
{
    public class PrescriptionRequestModelValidator : AbstractValidator<PrescriptionRequestModel>
    {
        public PrescriptionRequestModelValidator()
        {
            RuleFor(model => model.Medicine)
                .NotNull()
                .WithMessage("Medicine is required")
                .NotEqual(new Guid())
                .WithMessage("Medicine is required");

            RuleFor(model => model.Birds)
                .NotNull()
                .WithMessage("At least 1 bird must be selected");

            RuleFor(model => model.StartDate)
                .NotNull()
                .WithMessage("Start date is required");

            RuleFor(model => model.EndDate)
                .NotNull()
                .WithMessage("End date is required")
                .GreaterThan(model => model.StartDate)
                .WithMessage("End date must be greater than start date");



        }
    }
}
