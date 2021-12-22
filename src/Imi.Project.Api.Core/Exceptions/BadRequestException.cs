using System.Net;

namespace Imi.Project.Api.Core.Exceptions
{
    internal class BadRequestException : BaseException
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public BadRequestException(string message) : base(message)
        {

        }
    }
}
