using AutoMapper;
using Business.DTOs.Product;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<GetProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, GetProductDto>().ReverseMap();
        }
    }
}
