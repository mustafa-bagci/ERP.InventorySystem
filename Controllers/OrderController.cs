using Microsoft.AspNetCore.Mvc;
using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Services;

namespace ERP.InventorySystem.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
    
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
    
            return Ok(order);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            var createdOrder = await _orderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            var updatedOrder = await _orderService.UpdateOrderAsync(id, orderDto);
            if (updatedOrder == null)
                return NotFound();
    
            return Ok(updatedOrder);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (!result)
                return NotFound();
    
            return NoContent();
        }
    }
}
