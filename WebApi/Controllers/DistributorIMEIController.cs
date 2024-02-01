using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DistributorIMEIController : ControllerBase
    {
        private readonly IDistributorIMEIRepos _distributorIMEIRepos ;

        public DistributorIMEIController(IDistributorIMEIRepos distributorIMEIRepos)
        {
            _distributorIMEIRepos = distributorIMEIRepos ;
        }

        [HttpPost]
        public async Task<ActionResult> GetDistributorIMEIS()
        {

            try
            {
                return Ok(await _distributorIMEIRepos.GetDistributorImeis());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }


        [HttpPost]
        public async Task<ActionResult<object>> GetDistributorIMEI(int DistributorImeiId)
        {
            try
            {
                var result = await _distributorIMEIRepos.GetDistributorImei(DistributorImeiId);
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
        public async Task<ActionResult<object>> CreateDistributorIMEI([FromBody] DistibutorIMEIViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _distributorIMEIRepos.AddDistributorImei(model);
                return CreatedAtAction(nameof(GetDistributorIMEI), new { id = CreatedUser.DistributorId }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }



        [HttpPost]
        public async Task<ActionResult<object>> UpdateDistributorIMEI(int DistributorImeiId, [FromBody] DistibutorIMEIViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide Distributor IMEI data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var UpdateDistributorIMEI = await _distributorIMEIRepos.UpdateDistributorImei(DistributorImeiId, model);

                if (UpdateDistributorIMEI != null)
                {
                    return Ok(UpdateDistributorIMEI); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound(" not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> DeleteDistributorIMEI([FromBody] int DistributorImeiId)
        {
            try
            {
                if (DistributorImeiId == null)
                {
                    return BadRequest();
                }
                var CreatedDistributorIMEI = await _distributorIMEIRepos.DeleteDistributorImei(DistributorImeiId);
                return StatusCode(StatusCodes.Status201Created, CreatedDistributorIMEI);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
