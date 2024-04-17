using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Models;

namespace StorageWebAPI.Database
{
    public class StorageContext(DbContextOptions<StorageContext> options) : DbContext(options) {
        public DbSet<Product> Products { get; set; } = null!;
    }
}