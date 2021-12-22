using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Imi.Project.Api.Core.Exceptions
{
    internal class ItemNotFoundException : BaseException
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

        public ItemNotFoundException(string message) : base(message)
        {

        }

    }
}
