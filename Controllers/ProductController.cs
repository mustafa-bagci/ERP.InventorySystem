using Microsoft.AspNetCore.Mvc;
using ERP.InventorySystem.DTOs;
using ERP.InventorySystem.Models;
using ERP.InventorySystem.Services;

namespace ERP.InventorySystem.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
    
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
    
            return Ok(product);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            var createdProduct = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            var updatedProduct = await _productService.UpdateProductAsync(id, productDto);
            if (updatedProduct == null)
                return NotFound();
    
            return Ok(updatedProduct);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
                return NotFound();
    
            return NoContent();
        }
    }
}
