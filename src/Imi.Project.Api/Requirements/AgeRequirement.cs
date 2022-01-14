using Microsoft.AspNetCore.Authorization;

namespace Imi.Project.Api.Requirements
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public int RequiredMinimumAge { get; set; }
        public AgeRequirement(int age)
        {
            RequiredMinimumAge = age;
        }
    }
}