using CorpsInventoryManagementSystem.Data;
using CorpsInventoryManagementSystem.Interface;
using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace CorpsInventoryManagementSystem.Repositories
{
    public class SupplierRepository : ISupplier
    {
        private readonly InventoryDbContext dbContext;
        public SupplierRepository(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Supplier> AddNewSupplier(SupplierDTO supplier)
        {
            var isSupplierExist = await dbContext.Suppliers.FirstOrDefaultAsync(x => x.CompanyName == supplier.CompanyName);

            if(isSupplierExist == null)
            {
                var addSupplier = new Supplier
                {
                    SupplierId = SupplierIdFormat(supplier.SupplierId),
                    CompanyName = supplier.CompanyName, 
                    Address = supplier.Address,
                    City = supplier.City,
                    PostalCode = supplier.PostalCode,
                    Country = supplier.Country,
                    Phone = supplier.Phone
                };

                await dbContext.AddAsync(addSupplier);
                await dbContext.SaveChangesAsync();

                return addSupplier;
            }

            return null;
        }

        public async Task<List<Supplier>> DisplayAllSuppliers()
        {
            var displaySupplier = await dbContext.Suppliers.ToListAsync();
            return displaySupplier;
        }

        public async Task<Supplier> UpdateSupplier(SupplierDTO supplier)
        {
            var supplierDetail = await dbContext.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == supplier.SupplierId);

            if (supplierDetail != null)
            {
                supplierDetail.CompanyName = supplier.CompanyName;
                supplierDetail.Address = supplier.Address;  
                supplierDetail.City = supplier.City;
                supplierDetail.PostalCode = supplier.PostalCode;
                supplierDetail.Country = supplier.Country;
                supplierDetail.Phone = supplier.Phone;

                await dbContext.SaveChangesAsync();
                return supplierDetail;  
            }

            return null;
        }

        private string SupplierIdFormat(string supplierId)
        {
            var getLastId = dbContext.Suppliers.OrderByDescending(x => x.SupplierId).FirstOrDefault();

            if(getLastId == null)
            {
                return supplierId = "SP-001";
            }

            else
            {
                int lastId = int.Parse(getLastId.SupplierId.Split('-')[1]);
                return supplierId = $"SP-{(lastId + 1).ToString("D3")}";
            }
        }
    }
}
