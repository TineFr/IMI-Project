using Imi.Project.Blazor.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Models.Api
{
    public class CageRequestModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public ImageInfo ImageInfo { get; set; }
    }
}
