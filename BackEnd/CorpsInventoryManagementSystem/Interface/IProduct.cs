using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;

namespace CorpsInventoryManagementSystem.Interface
{
    public interface IProduct
    {
        Task<Product> AddNewProduct(ProductDTO product);
        Task<List<ViewProductDTO>> DisplayAllProduct();
    }
}
