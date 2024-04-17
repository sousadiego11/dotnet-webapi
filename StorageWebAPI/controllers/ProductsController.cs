using Microsoft.AspNetCore.Mvc;
using StorageWebAPI.Models;
using StorageWebAPI.Contracts.Models;
using StorageWebAPI.Services;
using StorageWebAPI.Mapping;

namespace StorageWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(ProductsService productsService) : ControllerBase {
        private readonly ILogger _logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger("ProductsController");

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponse>> PostProduct(ProductRequest req) {
            try {
                Product product = await productsService.PostProduct(req);
                ProductResponse resp = ProductMapping.FromDbEntityToResponse(product);
    
                _logger.LogInformation("[PostProduct]: {Message}", "Product created succesfully!");
                return CreatedAtAction(nameof(PostProduct), new { id = product.Id }, resp);
            }
            catch (Exception exception) {
                _logger.LogError("[PostProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponse>> GetProduct(Guid productId) {
            try {
                var product = await productsService.GetProduct(productId);

                _logger.LogInformation("[GetProduct]: {Message}", "Product fetched succesfully!");
                return product == null ? NotFound() : ProductMapping.FromDbEntityToResponse(product);
            }
            catch (Exception exception) {
                _logger.LogError("[GetProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponse>> RemoveProduct(Guid productId) {
            try {
                var product = await productsService.GetProduct(productId);
                if (product != null) {
                    productsService.RemoveProduct(productId);
                    _logger.LogInformation("[RemoveProduct]: {Message}", "Product removed succesfully!");
                    return NoContent();
                } else {
                    return NotFound();
                }
            }
            catch (Exception exception) {
                _logger.LogError("[RemoveProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }
    }
}