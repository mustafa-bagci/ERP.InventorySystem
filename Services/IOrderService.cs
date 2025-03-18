using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;

namespace ERP.InventorySystem.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(OrderDTO orderDto);
        Task<Order?> UpdateOrderAsync(int id, OrderDTO orderDto);
        Task<bool> DeleteOrderAsync(int id);
    }
}
