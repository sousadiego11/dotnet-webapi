using Microsoft.AspNetCore.Mvc;
using StorageWebAPI.Contracts.models;
using StorageWebAPI.Database;

namespace StorageWebAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(StorageContext context) : ControllerBase {
        private readonly StorageContext _context = context;
        private readonly ILogger logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger("ProductsController");

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            try {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
    
                return CreatedAtAction(nameof(PostProduct), new { id = product.Id }, product);
            }
            catch (Exception exception) {
                logger.LogError("[PostProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }
    }
}