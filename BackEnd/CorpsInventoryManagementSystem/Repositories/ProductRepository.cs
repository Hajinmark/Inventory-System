using CorpsInventoryManagementSystem.Data;
using CorpsInventoryManagementSystem.Interface;
using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace CorpsInventoryManagementSystem.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly InventoryDbContext dbContext;
        public ProductRepository(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> AddNewProduct(ProductDTO product)
        {
            var isProductExist =  await dbContext.Products.FirstOrDefaultAsync(x => x.ProductName == product.ProductName);

            if(isProductExist == null)
            {
                var addProduct = new Product
                {
                    ProductId = ProductIdFormat(product.ProductId),  
                    ProductName = product.ProductName,  
                    CategoryId = product.CategoryId,
                    SupplierId = product.SupplierId,    
                    QuantityPerUnit = product.QuantityPerUnit,
                    Field = product.Field
                };

                await dbContext.Products.AddAsync(addProduct);
                await dbContext.SaveChangesAsync();

                return addProduct;
            }

            return null;
        }

        public async Task<List<ViewProductDTO>> DisplayAllProduct()
        {
            List<ViewProductDTO> listProduct = new List<ViewProductDTO>();

            if (listProduct != null)
            {
                var product = await (from p in dbContext.Products
                                     join c in dbContext.Categories
                                     on p.CategoryId equals c.CategoryId
                                     join s in dbContext.Suppliers
                                     on p.SupplierId equals s.SupplierId
                                     select new ViewProductDTO
                                     {
                                         ProductId = p.ProductId,
                                         ProductName = p.ProductName,
                                         CategoryName = c.CategoryName,
                                         CompanyName = s.CompanyName,
                                         QuantityPerUnit = p.QuantityPerUnit,
                                         Field = p.Field
                                     }).ToListAsync();
                return product;
            }

            return null;
           
        }

        private string ProductIdFormat(string productId)
        {
            var productLastId = dbContext.Products
                .OrderByDescending(x => x.ProductId)
                .FirstOrDefault(); 

            if(productLastId == null)
            {
                return "PRD-001";
            }

            else
            {
                int lastId = int.Parse(productLastId.ProductId.Split('-')[1]);
                return productId = $"PRD-{(lastId + 1).ToString("D3")}";
            }

        }
    }
}
