namespace CorpsInventoryManagementSystem.Model.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActivated { get; set; }  

        //Navigation Property
        //public ICollection<Product> Product { get; set; }
    }
}