using FluentValidation;
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
                .WithMessage("Password cannot be empty");
        }
    }
}
