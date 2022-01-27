using Imi.Project.Blazor.Models.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Blazor.Models.Api
{
    public class CageRequestModel
    {
        [Required (ErrorMessage = "{0} is required")]
        [MaxLength(20, ErrorMessage = "Can not be longer than 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(20, ErrorMessage = "Can not be longer than 20 characters")]
        public string Location { get; set; }
        public ImageInfo ImageInfo { get; set; }
    }
}
