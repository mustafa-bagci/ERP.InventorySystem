using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;
using ERP.InventorySystem.Repositories;

namespace ERP.InventorySystem.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IProductRepository _productRepository;
    
        public StockMovementService(IStockMovementRepository stockMovementRepository, IProductRepository productRepository)
        {
            _stockMovementRepository = stockMovementRepository;
            _productRepository = productRepository;
        }
    
        public async Task<IEnumerable<StockMovement>> GetAllStockMovementsAsync()
        {
            return await _stockMovementRepository.GetAllAsync();
        }
    
        public async Task<StockMovement> CreateStockMovementAsync(StockMovementDTO stockMovementDto)
        {
            var product = await _productRepository.GetByIdAsync(stockMovementDto.ProductId);
            if (product == null)
                throw new Exception("Product not found");
    
            // Stok miktarını güncelle (giriş => arttır, çıkış => azalt)
            if (stockMovementDto.MovementType.ToLower() == "in")
            {
                product.StockQuantity += stockMovementDto.Quantity;
            }
            else if (stockMovementDto.MovementType.ToLower() == "out")
            {
                product.StockQuantity -= stockMovementDto.Quantity;
            }
            else
            {
                throw new Exception("Invalid movement type");
            }
    
            await _productRepository.UpdateAsync(product);
    
            var movement = new StockMovement
            {
                ProductId = stockMovementDto.ProductId,
                MovementType = stockMovementDto.MovementType,
                Quantity = stockMovementDto.Quantity,
                MovementDate = stockMovementDto.MovementDate
            };
    
            return await _stockMovementRepository.CreateAsync(movement);
        }
    }
}
