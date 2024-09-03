using System.ComponentModel.DataAnnotations.Schema;

namespace CorpsInventoryManagementSystem.Model.Domain
{
    public class Product
    {
        public  int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        [Column("CategoryId")]
        public string CategoryId { get; set; }
        [Column("SupplierId")]
        public string SupplierId { get; set; }  
        public decimal QuantityPerUnit { get; set; }    
        public string ? Field { get; set; } 

        // Navigation Property
        //public Category Category { get; set; }
        //public Supplier Supplier { get; set; }

    }
}
