using CorpsInventoryManagementSystem.Data;
using CorpsInventoryManagementSystem.Interface;
using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorpsInventoryManagementSystem.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly InventoryDbContext dbContext;
        public CategoryRepository(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }
        public async Task<Category> AddNewCategory(CategoryDTO category)
        {
            var isCategoryExist = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryName == category.CategoryName);
            
            if (isCategoryExist == null)
            {
                var categoryModel = new Category
                { 
                    CategoryId = CategoryIdFormat(category.CategoryId),
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    IsActivated = category.IsActivated
                };

                await dbContext.Categories.AddAsync(categoryModel);
                await dbContext.SaveChangesAsync();

                return categoryModel;
            }

            return null;
        }

        private string CategoryIdFormat(string categoryId)
        {
            var lastCategoryId = dbContext.Categories.OrderByDescending(x => x.CategoryId).FirstOrDefault();

            if (lastCategoryId == null)
            {
                categoryId = "CTG-001";
                return categoryId;
            }

            else
            {
                int lastId = int.Parse(lastCategoryId.CategoryId.Split('-')[1]);
                return categoryId = $"CTG-{(lastId + 1).ToString("D3")}";
            }
        }

        public async Task<List<Category>> DisplayCategories()
        {
            var showCategory = await dbContext.Categories.Take(10).ToListAsync();
            return showCategory;
        }

        public async Task<string> UpdateCategory(string categoryId, CategoryDTO updateCategory)
        {
            var category = await dbContext.Categories
                .Where(x => x.CategoryId == categoryId)
                .FirstOrDefaultAsync();

            string message = "";

            if (category != null)
            {
                category.CategoryName = updateCategory.CategoryName;
                category.Description = updateCategory.Description;
                category.IsActivated = updateCategory.IsActivated;

                dbContext.Update(category);
                await dbContext.SaveChangesAsync();

                message = "Successfully Updated";
                return message;
            }

            message = "Invalid Category Id";
            return message;

        }

        public async Task<int> CountCategory()
        {
            var count = await dbContext.Categories.CountAsync(x => x.IsActivated == true);

            if(count == 0)
            {
                return 0;
            }

            return count;
        }

        public async Task<List<Category>> SearchCategory([FromQuery] string? categoryId, string? categoryName)
        {
            var category = dbContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(categoryId) || !string.IsNullOrEmpty(categoryName))
            {
                var result = await category.Where(c => (c.CategoryId.Contains(categoryId)) ||
                                            (c.CategoryName.Contains(categoryName)) &&
                                            (c.IsActivated == true)).ToListAsync(); 
                    
                return result;
            }

            return await category.ToListAsync();
                

        }
    }
}
