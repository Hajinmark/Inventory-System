using CorpsInventoryManagementSystem.Model.Domain;

namespace CorpsInventoryManagementSystem.Model.DTO
{
    public class ProductDTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public string? Field { get; set; }
      
    }
}
