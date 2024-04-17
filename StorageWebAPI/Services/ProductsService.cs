using StorageWebAPI.Contracts.Models;
using StorageWebAPI.Database;
using StorageWebAPI.Mapping;
using StorageWebAPI.Models;

namespace StorageWebAPI.Services
{
    public class ProductsService(StorageContext context) {
        private readonly StorageContext _context = context;

        public async Task<Product> PostProduct(ProductRequest req) {
                Product product = ProductMapping.FromRequestToDbEntity(req);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return product;
        }

        public async Task<Product?> GetProduct(Guid productId) {
            return await _context.Products.FindAsync(productId);
        }

        public void RemoveProduct(Guid productId) {
            _context.Products.Remove(_context.Products.Single(p => p.Id == productId));
            _context.SaveChanges();
        }
        
    }
}