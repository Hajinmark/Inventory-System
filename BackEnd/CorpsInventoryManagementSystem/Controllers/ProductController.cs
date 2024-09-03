using CorpsInventoryManagementSystem.Interface;
using CorpsInventoryManagementSystem.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorpsInventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productRepository;
        public ProductController(IProduct productRepostory)
        {
            this.productRepository = productRepostory;  
        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct(ProductDTO product)
        {
            try
            {
                var addProduct = await productRepository.AddNewProduct(product);
                return Ok(addProduct);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpGet("DisplayAllProduct")]
        public async Task<IActionResult> DisplayAllProduct()
        {
            try
            {
                var product = await productRepository.DisplayAllProduct();
                return Ok(product); 
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
