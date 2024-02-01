using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepos _vendorRepos;

        public VendorController(IVendorRepos vendorRepos)
        {
            _vendorRepos = vendorRepos;
        }


        [HttpPost]
        public async Task<ActionResult> GetVendors()
        {

            try
            {
                return Ok(await _vendorRepos.GetVendors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }



        [HttpPost("{VendorId}")]
        public async Task<ActionResult<object>> GetVendor(int VendorId)
        {
            try
            {
                var result = await _vendorRepos.GetVendor(VendorId);
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


        [HttpPost("")]
        public async Task<ActionResult<object>> CreateVendor([FromBody] VendorViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _vendorRepos.AddVendor(model);
                return CreatedAtAction(nameof(GetVendor), new { id = CreatedUser.VendorName}, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }




        [HttpPost("")]
        public async Task<ActionResult<object>> UpdateVendor(int VendorId, [FromBody] VendorViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedCustomer = await _vendorRepos.UpdateVendor(VendorId, model);

                if (updatedCustomer != null)
                {
                    return Ok(updatedCustomer); // Return 200 OK with the updated customer
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



        [HttpPost("")]
        public async Task<ActionResult<object>> DeleteVendor([FromBody] int VendorId)
        {
            try
            {
                if (VendorId == null)
                {
                    return BadRequest();
                }
                var CreatedVendor = await _vendorRepos.DeleteVendor(VendorId);
                return StatusCode(StatusCodes.Status201Created, CreatedVendor);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }
    }
}
