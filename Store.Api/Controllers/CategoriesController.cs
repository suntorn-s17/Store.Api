using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;
using Store.Api.Models;
using Store.Api.Services.Categories;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Role.Admin},{Role.Operation}")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(IMapper mapper, ICategoriesService categoriesService)
        {
            _mapper = mapper;
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoriesService.GetCategoriesAsync();
            var response = _mapper.Map<List<CategoryResponseDto>>(categories);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var dto = _mapper.Map<Category>(request);
            var category = await _categoriesService.CreateCategoryAsync(dto);
            var response = _mapper.Map<CategoryResponseDto>(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoriesService.GetCategoryByIdAsync(id);
            var response = _mapper.Map<CategoryResponseDto>(category);
            return Ok(response);
        }
    }
}