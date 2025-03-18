using ERP.InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.InventorySystem.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Quantity)
                   .IsRequired();
    
            builder.Property(o => o.OrderDate)
                   .IsRequired();
    
            builder.HasOne(o => o.Product)
                   .WithMany()
                   .HasForeignKey(o => o.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
