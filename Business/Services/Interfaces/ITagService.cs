using Business.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    internal interface ITagService
    {
        Task<GetProductDto> CreateAsync(CreateProductDto dto);
        Task<GetProductDto> GetById(int id);
        Task Update(UpdateProductDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
    }
}
