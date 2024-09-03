namespace CorpsInventoryManagementSystem.Model.DTO
{
    public class ViewProductDTO
    {
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public string? Field { get; set; }
        public string? CategoryName { get; set; }
        public string? CompanyName { get; set; }
    }
}
