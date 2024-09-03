namespace CorpsInventoryManagementSystem.Model.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public string CompanyName { get; set; } 
        public string Address { get; set; } 
        public string City { get; set; }    
        public string PostalCode { get; set; }  
        public string Country { get; set; } 
        public string Phone { get; set; }   

        // Navigation Property
        //public ICollection<Product> Product { get; set; }

    }
}
