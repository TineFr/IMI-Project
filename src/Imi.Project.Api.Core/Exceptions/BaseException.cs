using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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
