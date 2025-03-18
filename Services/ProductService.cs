using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;
using ERP.InventorySystem.Repositories;

namespace ERP.InventorySystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
    
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    
        public async Task<Product> CreateProductAsync(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity
            };
    
            return await _productRepository.CreateAsync(product);
        }
    
        public async Task<Product?> UpdateProductAsync(int id, ProductDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return null;
    
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.StockQuantity = productDto.StockQuantity;
    
            return await _productRepository.UpdateAsync(product);
        }
    
        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
