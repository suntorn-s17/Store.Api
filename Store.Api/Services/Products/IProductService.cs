using Store.Api.Entities;

namespace Store.Api.Services.Products
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);

        Task<List<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(Guid id);

        Task<List<Product>?> GetProductByKeyword(string keyword);

        Task UpdateProductAsync(Guid id, Product updatedProduct);

        Task DeleteProductAsync(Guid id);
    }
}