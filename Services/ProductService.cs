using crud.DAL;
using crud.Models;

namespace crud.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name)) // Use product.Name for validation
            {
                throw new ArgumentException("O nome do produto é obrigatório.");
            }

            await _productRepository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name)) // Use product.Name for validation
            {
                throw new ArgumentException("O nome do produto é obrigatório.");
            }

            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}