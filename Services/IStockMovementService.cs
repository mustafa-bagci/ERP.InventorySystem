using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;

namespace ERP.InventorySystem.Services
{
    public interface IStockMovementService
    {
        Task<IEnumerable<StockMovement>> GetAllStockMovementsAsync();
        Task<StockMovement> CreateStockMovementAsync(StockMovementDTO stockMovementDto);
    }
}
