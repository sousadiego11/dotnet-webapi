using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Contracts.models;

namespace StorageWebAPI.Database
{
    public class StorageContext(DbContextOptions<StorageContext> options) : DbContext(options){
        public DbSet<Product> Products { get; set; } = null!;
    }
}