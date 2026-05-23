using Microsoft.EntityFrameworkCore;
using Store.Api.Entities;
using Store.Api.Exceptions;

namespace Store.Api.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategoriesService> _logger;

        public CategoriesService(
            AppDbContext context,
            ILogger<CategoriesService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _logger.LogInformation("Creating category: {CategoryName}", category.CategoryName);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Category created successfully. CategoryId: {CategoryId}", category.Id);

            return category;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            _logger.LogInformation("Retrieving all categories");

            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} categories", categories.Count);

            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving category by id: {CategoryId}", id);

            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                _logger.LogWarning("Category not found. CategoryId: {CategoryId}", id);

                throw new NotFoundException("Invalid category id, Category not found");
            }

            _logger.LogInformation("Category found. CategoryId: {CategoryId}", id);

            return category;
        }
    }
}