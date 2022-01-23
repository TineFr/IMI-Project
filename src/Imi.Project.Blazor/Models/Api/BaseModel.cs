using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Models.Api
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string ErrorMessage { get; set; }
    }
}
