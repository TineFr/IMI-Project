﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
