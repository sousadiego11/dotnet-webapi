using Microsoft.AspNetCore.Mvc;
using StorageWebAPI.Contracts.models;
using StorageWebAPI.Database;

namespace StorageWebAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StorageContext? _context;

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            _context!.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostProduct), new { id = product.Id }, product);
        }
    }
}