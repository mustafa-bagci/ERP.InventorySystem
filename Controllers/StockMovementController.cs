using Microsoft.AspNetCore.Mvc;
using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Services;

namespace ERP.InventorySystem.Controllers
{
    [Route("api/stockmovements")]
    [ApiController]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _stockMovementService;
    
        public StockMovementController(IStockMovementService stockMovementService)
        {
            _stockMovementService = stockMovementService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movements = await _stockMovementService.GetAllStockMovementsAsync();
            return Ok(movements);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ERP.InventorySystem.DTOs.StockMovementDTO stockMovementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            var createdMovement = await _stockMovementService.CreateStockMovementAsync(stockMovementDto);
            return CreatedAtAction(nameof(GetAll), new { id = createdMovement.Id }, createdMovement);
        }
    }
}
