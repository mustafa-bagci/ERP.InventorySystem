using ERP.InventorySystem.Models;
using ERP.InventorySystem.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ERP.InventorySystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Order> Orders { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StockMovementConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
