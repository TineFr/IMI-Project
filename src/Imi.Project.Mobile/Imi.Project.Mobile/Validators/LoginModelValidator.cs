﻿using FluentValidation;
using Imi.Project.Mobile.Core.Models.Api.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginModelValidator()
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
        }
    }
}
