using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;


namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepos _productRepos;

        public ProductController(IProductRepos productRepos)
        {
            _productRepos = productRepos;
        }



        [HttpPost]
        public async Task<ActionResult> GetProducts()
        {

            try
            {
                return Ok(await _productRepos.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }


        [HttpPost]
        public async Task<ActionResult<object>> GetProduct([FromBody] int ProductId)
        {
            try
            {
                var result = await _productRepos.GetProduct(ProductId);
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
        public async Task<ActionResult<object>> CreateProduct([FromBody] ProductViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _productRepos.AddProduct(model);
                return CreatedAtAction(nameof(GetProduct), new { id = CreatedUser.MarketName }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdateProduct([FromBody] ProductViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid Product data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedProduct = await _productRepos.UpdateProduct(model);

                if (updatedProduct != null)
                {
                    return Ok(updatedProduct); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Product not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<object>> DeleteProduct([FromBody] int ProductId)
        {
            try
            {
                if (ProductId == null)
                {
                    return BadRequest();
                }
                var CreatedProduct = await _productRepos.DeleteProduct(ProductId);
                return StatusCode(StatusCodes.Status201Created, CreatedProduct);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }
    }
}
