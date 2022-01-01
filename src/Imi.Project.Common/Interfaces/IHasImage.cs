using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common.Interfaces
{
    public interface IHasImage
    {
         IFormFile Image { get; set; }
    }
}
