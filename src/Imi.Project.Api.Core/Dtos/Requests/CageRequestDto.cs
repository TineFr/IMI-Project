using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Requests
{
    public class CageRequestDto : BaseEntityDto
    {
        public string Image { get; set; }
        public string Location { get; set; }
    }
}
