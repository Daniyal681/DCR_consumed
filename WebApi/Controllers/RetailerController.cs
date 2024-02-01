using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RetailerController : ControllerBase
    {

        private readonly IRetailorRepos _retailorRepos;

        public RetailerController(IRetailorRepos retailorRepos)
        {
            _retailorRepos = retailorRepos;
        }


        [HttpPost]
        public async Task<ActionResult> GetRetailers()
        {

            try
            {
                return Ok(await _retailorRepos.GetRetailers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }


        [HttpPost]
        public async Task<ActionResult<object>> GetRetailer(int RetailerId)
        {
            try
            {
                var result = await _retailorRepos.GetRetailer(RetailerId);
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
        public async Task<ActionResult<object>> CreateRetailer([FromBody] RetailerViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _retailorRepos.AddRetailer(model);
                return CreatedAtAction(nameof(GetRetailer), new { id = CreatedUser.RetailerName}, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdateRetailer(int RetailerId, [FromBody] RetailerViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid Retailer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedRetailer = await _retailorRepos.UpdateRetailer(RetailerId, model);

                if (updatedRetailer != null)
                {
                    return Ok(updatedRetailer); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Retailer not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> DeleteRetailer([FromBody] int RetailerId)
        {
            try
            {
                if (RetailerId == null)
                {
                    return BadRequest();
                }
                var CreatedRetailer = await _retailorRepos.DeleteRetailer(RetailerId);
                return StatusCode(StatusCodes.Status201Created, CreatedRetailer);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }
    }
}
