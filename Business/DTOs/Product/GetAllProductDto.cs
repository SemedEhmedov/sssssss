﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Product
{
    public class GetAllProductDto
    {
        public IQueryable<GetProductDto> models { get; set; }
    }
}
