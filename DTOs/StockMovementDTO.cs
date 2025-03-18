namespace ERP.InventorySystem.DTOs
{
    public class StockMovementDTO
    {
        public int ProductId { get; set; }
        public string MovementType { get; set; } // "in" veya "out"
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
