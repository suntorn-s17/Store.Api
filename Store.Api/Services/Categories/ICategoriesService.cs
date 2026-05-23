using Store.Api.Entities;

namespace Store.Api.Services.Categories
{
    public interface ICategoriesService
    {
        Task<Category> CreateCategoryAsync(Category category);

        Task<List<Category>> GetCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(Guid id);
    }
}