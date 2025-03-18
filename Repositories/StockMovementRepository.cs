using ERP.InventorySystem.Data;
using ERP.InventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.InventorySystem.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly ApplicationDbContext _context;
    
        public StockMovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<StockMovement>> GetAllAsync()
        {
            return await _context.StockMovements.ToListAsync();
        }
    
        public async Task<StockMovement> CreateAsync(StockMovement stockMovement)
        {
            _context.StockMovements.Add(stockMovement);
            await _context.SaveChangesAsync();
            return stockMovement;
        }
    }
}
