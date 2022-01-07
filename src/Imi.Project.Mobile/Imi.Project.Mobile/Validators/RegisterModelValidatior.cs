using FluentValidation;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Validators
{
    public class RegisterModelValidatior : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidatior()
        {
            RuleFor(model => model.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .EmailAddress()
                .WithMessage("Email not in correct format");


            RuleFor(model => model.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.");


            RuleFor(model => model.ConfirmPassword)
                .Equal(model => model.Password)
                .WithMessage("Must be equal to password");


            RuleFor(model => model.DateOfBirth)
                .NotNull()
                .WithMessage("Date of birth is required")
                .GreaterThan(b => DateTime.Now.Date)
                .WithMessage("Date of birth cannot be a future date");

            RuleFor(model => model.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty");

            RuleFor(model => model.FirstName)
                .NotEmpty()
                .WithMessage("First name cannot be empty");

        }
    }
}
