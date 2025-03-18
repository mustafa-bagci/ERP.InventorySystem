using ERP.InventorySystem.Models;

namespace ERP.InventorySystem.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<bool> DeleteAsync(int id);
    }
}
