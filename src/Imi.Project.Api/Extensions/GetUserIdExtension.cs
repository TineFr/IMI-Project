using System;
using System.Security.Claims;

namespace Imi.Project.Api.Extensions
{
    public static class GetUserIdExtension
    {
        public static Guid GetUser(this ClaimsPrincipal principal)
        {
            Guid userId = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }
    }
}
