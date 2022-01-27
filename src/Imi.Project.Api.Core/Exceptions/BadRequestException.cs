using System.Net;

namespace Imi.Project.Api.Core.Exceptions
{
    internal class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
