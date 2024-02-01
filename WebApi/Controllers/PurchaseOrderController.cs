using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderRepos _purchaseOrderRepos;

        public PurchaseOrderController(IPurchaseOrderRepos purchaseOrderRepos)
        {
            _purchaseOrderRepos = purchaseOrderRepos;
        }



        [HttpPost]
        public async Task<ActionResult> GetPurchaseOrders()
        {

            try
            {
                return Ok(await _purchaseOrderRepos.GetPurchaseOrders());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }



        [HttpPost]
        public async Task<ActionResult<object>> GetPurchaeOrder(int PurchaseId)
        {
            try
            {
                var result = await _purchaseOrderRepos.GetPurchaseOrder(PurchaseId);
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
        public async Task<ActionResult<object>> CreatePurchaseOrder([FromBody] PurchaseOrderViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _purchaseOrderRepos.AddPurchaseOrder(model);
                return CreatedAtAction(nameof(GetPurchaeOrder), new { id = CreatedUser.PurchaseName }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdatePurchaseOrder(int PurchaseId, [FromBody] PurchaseOrderViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid Purchase data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var UpdatePurchaseOrder = await _purchaseOrderRepos.UpdatePurchaseOrder(PurchaseId, model);

                if (UpdatePurchaseOrder != null)
                {
                    return Ok(UpdatePurchaseOrder); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Purchase not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<object>> DeletePurchaseOrder([FromBody] int PurchaseId)
        {
            try
            {
                if (PurchaseId == null)
                {
                    return BadRequest();
                }
                var CreatedPurchaseOrder = await _purchaseOrderRepos.DeletePurchaseOrder(PurchaseId);
                return StatusCode(StatusCodes.Status201Created, CreatedPurchaseOrder);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
