using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductWarehouseController : ControllerBase
    {
        private readonly IProductWarehouseRepos _productWarehouseRepos;

        public ProductWarehouseController(IProductWarehouseRepos productWarehouseRepos)
        {
            _productWarehouseRepos = productWarehouseRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetProductWarehouses()
        {

            try
            {
                return Ok(await _productWarehouseRepos.GetProductWarehouses());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }


        [HttpPost]
        public async Task<ActionResult<object>> GetProductWarehouse(int ProductWarehouseId)
        {
            try
            {
                var result = await _productWarehouseRepos.GetProductWarehouse(ProductWarehouseId);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }


        [HttpPost]
        public async Task<ActionResult<object>> CreateProductWarehouse([FromBody] ProductWarehouseViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _productWarehouseRepos.AddProductWarehouse(model);
                return CreatedAtAction(nameof(GetProductWarehouse), new { id = CreatedUser.ProductId }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdateProductWarehouse(int ProductWarehouseId, [FromBody] ProductWarehouseViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid Product Warehouse data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var UpdateProductWarehouse = await _productWarehouseRepos.UpdateProductWarehouse(ProductWarehouseId, model);

                if (UpdateProductWarehouse != null)
                {
                    return Ok(UpdateProductWarehouse); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Product Warehouse not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<object>> DeleteProductWarehouse([FromBody] int ProductWarehouseId)
        {
            try
            {
                if (ProductWarehouseId == null)
                {
                    return BadRequest();
                }
                var CreatedProductWarehouse = await _productWarehouseRepos.DeleteProductWarehouse(ProductWarehouseId);
                return StatusCode(StatusCodes.Status201Created, CreatedProductWarehouse);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
