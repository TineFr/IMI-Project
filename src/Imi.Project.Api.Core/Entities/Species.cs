﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Species : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        public string ScientificName { get; set; }
        public List<Bird> Birds { get; set; }
    }
}
