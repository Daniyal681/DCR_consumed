using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorRepos _distributorRepos;

        public DistributorController(IDistributorRepos distributorRepos)
        {
            _distributorRepos = distributorRepos;   
        }

        [HttpPost]
        public async Task<ActionResult> GetDistributors()
        {

            try
            {
                return Ok(await _distributorRepos.GetDistributors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }
        
        [HttpPost]
        public async Task<ActionResult<object>> GetDistributor(int DistributorId)
        {
            try
            {
                var result = await _distributorRepos.GetDistributor(DistributorId);
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
        public async Task<ActionResult<object>> CreateDistributor([FromBody] DistributorViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _distributorRepos.AddDistributor(model);
                return CreatedAtAction(nameof(GetDistributor), new { id = CreatedUser.DistributorName }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdateCustomer(int DistributorId, [FromBody] DistributorViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedDistributor = await _distributorRepos.UpdateDistributor(DistributorId, model);

                if (updatedDistributor != null)
                {
                    return Ok(updatedDistributor); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Customer not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<object>> DeleteCustomer([FromBody] int DistributorId)
        {
            try
            {
                if (DistributorId == null)
                {
                    return BadRequest();
                }
                var CreatedDistributor = await _distributorRepos.DeleteDistributor(DistributorId);
                return StatusCode(StatusCodes.Status201Created, CreatedDistributor);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }
    }
}
