using Microsoft.EntityFrameworkCore;
using Store.Api.Entities;
using Store.Api.Exceptions;

namespace Store.Api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(AppDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _logger.LogInformation("Creating product: {ProductName}", product.ProductName);

            var category = await _context.Categories
                .FirstOrDefaultAsync(
                    c => c.Id == product.CategoryId);

            if (category == null)
            {
                _logger.LogWarning("Create product failed. Invalid CategoryId: {CategoryId}", product.CategoryId);

                throw new NotFoundException("Invalid category id");
            }

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Product created successfully. ProductId: {ProductId}", product.Id);

            return product;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            _logger.LogInformation("Deleting product. ProductId: {ProductId}", id);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                _logger.LogWarning("Delete failed. Product not found. ProductId: {ProductId}", id);

                throw new NotFoundException("Invalid product id, Product not found");
            }

            _context.Remove(product);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Product deleted successfully. ProductId: {ProductId}", id);
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving product. ProductId: {ProductId}", id);

            var product = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                _logger.LogWarning("Product not found. ProductId: {ProductId}", id);

                throw new NotFoundException("Invalid product id, Product not found");
            }

            return product;
        }

        public async Task<List<Product>> GetProductByKeyword(
            string keyword)
        {
            _logger.LogInformation("Searching products by keyword");

            var products = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.ProductName.Contains(keyword))
                .ToListAsync();

            _logger.LogInformation("Found {Count} products", products.Count);

            return products;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            _logger.LogInformation("Retrieving all products");

            var products = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} products", products.Count);

            return products;
        }

        public async Task UpdateProductAsync(Guid id, Product updatedProduct)
        {
            _logger.LogInformation("Updating product. ProductId: {ProductId}", id);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                _logger.LogWarning("Update failed. Product not found. ProductId: {ProductId}", id);

                throw new NotFoundException("Invalid product id, Product not found");
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(
                    c => c.Id == updatedProduct.CategoryId);

            if (category == null)
            {
                _logger.LogWarning("Update failed. Invalid CategoryId: {CategoryId}", updatedProduct.CategoryId);

                throw new NotFoundException("Invalid category id, Category not found");
            }

            product.ProductName = updatedProduct.ProductName;
            product.ProductDescription = updatedProduct.ProductDescription;
            product.ProductPrice = updatedProduct.ProductPrice;
            product.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Product updated successfully. ProductId: {ProductId}", id);
        }
    }
}