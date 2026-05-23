using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;
using Store.Api.Models;
using Store.Api.Services.Products;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Role.Admin},{Role.Operation}")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestDto request)
        {
            var dto = _mapper.Map<Product>(request);
            var product = await _productService.CreateProductAsync(dto);
            var response = _mapper.Map<ProductResponseDto>(product);
            return CreatedAtAction(nameof(GetProductById), new { response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            var response = _mapper.Map<List<ProductResponseDto>>(products);
            return Ok(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var response = _mapper.Map<ProductResponseDto>(product);
            return Ok(response);
        }

        [HttpGet("keyword/{keyword}")]
        public async Task<IActionResult> GetProductByKeyWord(string keyword)
        {
            var products = await _productService.GetProductByKeyword(keyword);
            var response = _mapper.Map<List<ProductResponseDto>>(products);
            return Ok(response);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductRequestDto request)
        {
            var dto = _mapper.Map<Product>(request);
            await _productService.UpdateProductAsync(id, dto);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}