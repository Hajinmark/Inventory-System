using CorpsInventoryManagementSystem.Interface;
using CorpsInventoryManagementSystem.Model.Domain;
using CorpsInventoryManagementSystem.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorpsInventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoryRepository;
       // private readonly DbContext dbContext;
        public CategoryController(ICategory categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            //this.dbContext = dbContext;
        }

        [HttpPost("AddNewCategory")]
        public async Task <IActionResult> AddNewCategory([FromBody]CategoryDTO category)
        {
            try
            {
                var newCategory = await categoryRepository.AddNewCategory(category);

                return Ok(newCategory);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("DisplayCategories")]
        public async Task<IActionResult> DisplayCategories()
        {
            try
            {
               var categories = await categoryRepository.DisplayCategories();
               return Ok(categories);
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);  
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(string? categoryId, CategoryDTO category)
        {
            try
            {
                var categoryModel = await categoryRepository.UpdateCategory(categoryId, category);

                if(categoryModel.ToString() == "Successfully Updated")
                {
                    return Ok(categoryModel.ToString());
                }

                return NotFound(categoryModel.ToString());  
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CountCategory")]
        public async Task<IActionResult> CountCategory()
        {
            try
            {
                var count  = await categoryRepository.CountCategory();

                if(count != 0)
                {
                    return Ok(count);
                }

                return NotFound(count);
                
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SearchCategory")]
        public async Task<IActionResult> SearchCategory([FromQuery]string? categoryId, string? categoryName)
        {
            try
            {
                var category = await categoryRepository.SearchCategory(categoryId, categoryName);

                return Ok(category);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
