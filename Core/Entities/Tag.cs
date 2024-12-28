﻿using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        List<ProductTag> ProductTags { get; set; }
    }
}