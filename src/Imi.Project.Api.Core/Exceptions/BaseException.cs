using System;
using System.Net;

namespace Imi.Project.Api.Core.Exceptions
{
    public class BaseException : SystemException
    {
        public HttpStatusCode StatusCode { get; set; }
        public BaseException(string message) : base(message)
        {
        }
    }
}
