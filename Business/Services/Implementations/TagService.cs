using AutoMapper;
using Business.DTOs.Product;
using Business.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    class TagService:ITagService
    {
        readonly IProductRepository _repo;
        readonly IMapper _mapper;

        public TagService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<GetProductDto> CreateAsync(CreateProductDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception();
            }
            var product = _mapper.Map<Product>(dto);
            var newproduct = await _repo.Create(product);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetProductDto>(newproduct);
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);
            _repo.Delete(_mapper.Map<Product>(product));
            await _repo.SaveChangesAsync();
        }

        public async Task<GetProductDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }
            GetProductDto dto = _mapper.Map<GetProductDto>(await _repo.GetbyId(id));
            return dto != null ? dto : throw new Exception();
        }

        public async Task SoftDelete(int id)
        {
            var product = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Product>(product));
            await _repo.SaveChangesAsync();
        }

        public async Task Update(UpdateProductDto dto)
        {
            var oldproduct = await GetById(dto.Id);
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception();
            }
            oldproduct = _mapper.Map<GetProductDto>(dto);
            _repo.Update(_mapper.Map<Product>(oldproduct));
            await _repo.SaveChangesAsync();
        }
    }
}
