using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;
using ERP.InventorySystem.Repositories;

namespace ERP.InventorySystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
    
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
    
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }
    
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }
    
        public async Task<Order> CreateOrderAsync(OrderDTO orderDto)
        {
            var product = await _productRepository.GetByIdAsync(orderDto.ProductId);
            if (product == null)
                throw new Exception("Product not found");
    
            var order = new Order
            {
                ProductId = orderDto.ProductId,
                Quantity = orderDto.Quantity,
                OrderDate = orderDto.OrderDate
            };
    
            return await _orderRepository.CreateAsync(order);
        }
    
        public async Task<Order?> UpdateOrderAsync(int id, OrderDTO orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                return null;
    
            order.ProductId = orderDto.ProductId;
            order.Quantity = orderDto.Quantity;
            order.OrderDate = orderDto.OrderDate;
    
            return await _orderRepository.UpdateAsync(order);
        }
    
        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
    }
}
