using System.Net;

namespace Imi.Project.Api.Core.Exceptions
{
    internal class ItemNotFoundException : BaseException
    {
        public ItemNotFoundException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
