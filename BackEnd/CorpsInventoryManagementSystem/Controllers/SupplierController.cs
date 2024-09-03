using CorpsInventoryManagementSystem.Interface;
using CorpsInventoryManagementSystem.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorpsInventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplier supplierRepository;
        public SupplierController(ISupplier supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        [HttpPost("AddNewSupplier")]
        public async Task<IActionResult> AddNewSupplier(SupplierDTO supplier)
        {
            try
            {
                var addSupplier =  await supplierRepository.AddNewSupplier(supplier);
                return Ok(addSupplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DisplayAllSuppliers")]
        public async Task<IActionResult> DisplayAllSuppliers()
        {
            try
            {
                var displaySuppliers = await supplierRepository.DisplayAllSuppliers();
                return Ok(displaySuppliers);   
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier(SupplierDTO supplier)
        {
            try
            {
                var supplierUpdate = await supplierRepository.UpdateSupplier(supplier); 
                return Ok(supplierUpdate);  
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
