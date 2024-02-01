using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepos _paymentRepos;

        public PaymentController(IPaymentRepos paymentRepos)
        {
            _paymentRepos = paymentRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetPayments()
        {

            try
            {
                return Ok(await _paymentRepos.GetPayments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<object>> GetPayment(int PaymentId)
        {
            try
            {
                var result = await _paymentRepos.GetPayment(PaymentId);
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
        public async Task<ActionResult<object>> CreateInventory([FromBody] PaymentViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _paymentRepos.AddPayment(model);
                return CreatedAtAction(nameof(GetPayment), new { id = CreatedUser.DistributorId }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdatePayment(int PaymentId, [FromBody] PaymentViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedPayment = await _paymentRepos.UpdatePayment(PaymentId, model);

                if (updatedPayment != null)
                {
                    return Ok(updatedPayment); // Return 200 OK with the updated customer
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
        public async Task<ActionResult<object>> DeletePayment([FromBody] int PaymentId)
        {
            try
            {
                if (PaymentId == null)
                {
                    return BadRequest();
                }
                var CreatedPayment = await _paymentRepos.DeletePayment(PaymentId);
                return StatusCode(StatusCodes.Status201Created, CreatedPayment);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
