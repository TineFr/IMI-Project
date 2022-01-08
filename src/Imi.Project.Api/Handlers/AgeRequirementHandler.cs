using Imi.Project.Api.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Handlers
{
    public class AgeRequirementHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            var required = requirement.RequiredMinimumAge;
            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(ClaimTypes.DateOfBirth).Value);
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))age--;

            if (age >= required)
            {
                context.Succeed(requirement);
            }



            return Task.CompletedTask;
        }
    }
}
