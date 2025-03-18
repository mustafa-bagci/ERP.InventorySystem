using ERP.InventorySystem.Models;

namespace ERP.InventorySystem.Repositories
{
    public interface IStockMovementRepository
    {
        Task<IEnumerable<StockMovement>> GetAllAsync();
        Task<StockMovement> CreateAsync(StockMovement stockMovement);
    }
}
