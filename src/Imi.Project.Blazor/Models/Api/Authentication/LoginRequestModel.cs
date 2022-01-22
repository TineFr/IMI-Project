using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Blazor.Models.Api
{ 
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
