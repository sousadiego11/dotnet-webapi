using Microsoft.AspNetCore.Mvc;
using StorageWebAPI.Models;
using StorageWebAPI.Contracts.Models;
using StorageWebAPI.Services;
using StorageWebAPI.Mapping;

namespace StorageWebAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(ProductsService productsService) : ControllerBase {
        private readonly ProductsService productsService = productsService;
        private readonly ILogger logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger("ProductsController");

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponse>> PostProduct(ProductRequest req) {
            try {
                Product product = await productsService.PostProduct(req);
                ProductResponse resp = ProductMapping.FromDbEntityToResponse(product);
    
                logger.LogInformation("[PostProduct]: {Message}", "Product created succesfully!");
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
                var product = await productsService.GetProduct(productId);

                logger.LogInformation("[GetProduct]: {Message}", "Product fetched succesfully!");
                return product == null ? NotFound() : ProductMapping.FromDbEntityToResponse(product);
            }
            catch (Exception exception) {
                logger.LogError("[GetProduct]: {Message}", exception.Message);
                return StatusCode(500);
            }
        }
    }
}