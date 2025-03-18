using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;

namespace ERP.InventorySystem.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductDTO productDto);
        Task<Product?> UpdateProductAsync(int id, ProductDTO productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
