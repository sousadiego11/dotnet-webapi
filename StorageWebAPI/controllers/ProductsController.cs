using Microsoft.AspNetCore.Mvc;
using StorageWebAPI.Models;
using StorageWebAPI.Database;
using StorageWebAPI.Contracts.Models;

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
        public async Task<ActionResult<ProductResponse>> PostProduct(ProductRequest req) {
            try {
                Product product = new(req.Name, req.UnitPrice, req.PricePerWeight, req.Categories);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                ProductResponse resp = new ProductResponse{
                        Categories = product.Categories,
                        Id = product.Id,
                        Name = product.Name,
                        PricePerWeight = product.PricePerWeight,
                        UnitPrice = product.UnitPrice,
                        CreatedAt = product.CreatedAt,
                        UpdatedAt = product.UpdatedAt,
                    };
    
                return CreatedAtAction(nameof(PostProduct), new { id = product.Id }, resp);
            }
            catch (Exception exception) {
                logger.LogError("[PostProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponse>> GetProduct(Guid productId) {
            try {
                var product = await _context.Products.FindAsync(productId);
                if (product == null) {
                    return NotFound();
                } else {
                    return new ProductResponse{
                        Categories = product.Categories,
                        Id = product.Id,
                        Name = product.Name,
                        PricePerWeight = product.PricePerWeight,
                        UnitPrice = product.UnitPrice,
                        CreatedAt = product.CreatedAt,
                        UpdatedAt = product.UpdatedAt,
                    };
                }
            }
            catch (Exception exception) {
                logger.LogError("[GetProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }
    }
}