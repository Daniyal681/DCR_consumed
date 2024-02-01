using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesOrderDetailController : ControllerBase
    {
        private readonly ISalesOrderDetail _saleOrderRepos;

        public SalesOrderDetailController(ISalesOrderDetail saleOrderRepos)
        {
            _saleOrderRepos = saleOrderRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetSalesOrderDetails()
        {

            try
            {
                return Ok(await _saleOrderRepos.GetSalesOrderDetails());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<object>> GetSalesOrderDetail(int SalesOrderDetailId)
        {
            try
            {
                var result = await _saleOrderRepos.GetSalesOrderDetail(SalesOrderDetailId);
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
        public async Task<ActionResult<object>> CreateSalesOrderDetail([FromBody] SalesOrderDetailViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _saleOrderRepos.AddSalesOrderDetail(model);
                return CreatedAtAction(nameof(GetSalesOrderDetail), new { id = CreatedUser.ProductId }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdateSalesOrderDetail(int SalesOrderDetailId, [FromBody] SalesOrderDetailViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedSalesOrderDetail = await _saleOrderRepos.UpdateSalesOrderDetail(SalesOrderDetailId, model);

                if (updatedSalesOrderDetail != null)
                {
                    return Ok(updatedSalesOrderDetail); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("!Not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<object>> DeletePayment([FromBody] int SalesOrderDetailId)
        {
            try
            {
                if (SalesOrderDetailId == null)
                {
                    return BadRequest();
                }
                var CreatedSalesOrderDetail = await _saleOrderRepos.DeleteSalesOrderDetail(SalesOrderDetailId);
                return StatusCode(StatusCodes.Status201Created, CreatedSalesOrderDetail);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
