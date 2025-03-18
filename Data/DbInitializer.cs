using ERP.InventorySystem.Models;

namespace ERP.InventorySystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
    
            // Eğer veriler varsa çık
            if (context.Products.Any())
                return;
    
            var products = new Product[]
            {
                new Product { Name = "Laptop", Description = "Dell XPS 13", Price = 1500, StockQuantity = 10 },
                new Product { Name = "Monitor", Description = "24 inch LED", Price = 200, StockQuantity = 25 }
            };
    
            foreach (var p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
