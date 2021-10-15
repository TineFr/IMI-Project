﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Cage : BaseEntity
    {
        public List<Bird> Birds { get; set; }
        public List<Task> Tasks { get; set; }
        public string Image { get; set; }
    }
}
