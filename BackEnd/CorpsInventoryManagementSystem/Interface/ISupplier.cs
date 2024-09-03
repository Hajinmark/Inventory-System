using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;

namespace CorpsInventoryManagementSystem.Interface
{
    public interface ISupplier
    {
        Task<Supplier> AddNewSupplier(SupplierDTO supplier);
        Task<List<Supplier>> DisplayAllSuppliers();
        Task<Supplier> UpdateSupplier(SupplierDTO supplier);
    }
}
