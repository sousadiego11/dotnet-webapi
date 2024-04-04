using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Contracts.models;

namespace StorageWebAPI.database
{
    public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options){
        public DbSet<Product> Products { get; set; } = null!;
    }
}