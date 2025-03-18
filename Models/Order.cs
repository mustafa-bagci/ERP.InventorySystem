namespace ERP.InventorySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    
        public Product? Product { get; set; }
    }
}
