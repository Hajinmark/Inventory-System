using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;

namespace CorpsInventoryManagementSystem.Interface
{
    public interface ICategory
    {
        Task<Category> AddNewCategory(CategoryDTO category);
        Task<List<Category>> DisplayCategories();
        Task<string> UpdateCategory(string categoryId, CategoryDTO updateCategory);
        Task<int> CountCategory();
        Task<List<Category>> SearchCategory(string categoryId, string categoryName);
    }
}
