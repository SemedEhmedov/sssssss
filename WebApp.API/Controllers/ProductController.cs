using Business.DTOs.Product;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateProductDto dto)
        {
            try
            {
                return Ok(await _productService.CreateAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductDto dto)
        {
            try
            {
                await _productService.Update(dto);
                return Ok();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{action}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{action}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _productService.SoftDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
