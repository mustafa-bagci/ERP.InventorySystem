using ERP.InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.InventorySystem.Configurations
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.HasKey(sm => sm.Id);
            builder.Property(sm => sm.MovementType)
                   .IsRequired()
                   .HasMaxLength(10);
    
            builder.Property(sm => sm.Quantity)
                   .IsRequired();
    
            builder.Property(sm => sm.MovementDate)
                   .IsRequired();
    
            builder.HasOne(sm => sm.Product)
                   .WithMany()
                   .HasForeignKey(sm => sm.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
