using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Contracts.models;

namespace StorageWebAPI.database
{
    public class StorageContext(DbContextOptions<StorageContext> options) : DbContext(options){
        public DbSet<Product> Products { get; set; } = null!;
    }
}