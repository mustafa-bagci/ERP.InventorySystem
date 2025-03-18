namespace ERP.InventorySystem.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string MovementType { get; set; } // "in" or "out"
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
    
        public Product? Product { get; set; }
    }
}
