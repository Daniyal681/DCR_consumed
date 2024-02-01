using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiveController : ControllerBase
    {

        private readonly IReceiveRepos _receiveRepos;

        public ReceiveController(IReceiveRepos receiveRepos)
        {
            _receiveRepos = receiveRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetReceives()
        {

            try
            {
                return Ok(await _receiveRepos.GetReceives());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<object>> GetReceive(int ReceiveId)
        {
            try
            {
                var result = await _receiveRepos.GetReceive(ReceiveId);
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
        public async Task<ActionResult<object>> CreateReceive([FromBody] ReceiveViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _receiveRepos.AddReceive(model);
                return CreatedAtAction(nameof(GetReceive), new { id = CreatedUser.DistributorId }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> UpdateReceive(int ReceiveId, [FromBody] ReceiveViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid Recieve data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedReceive = await _receiveRepos.UpdateReceive(ReceiveId, model);

                if (updatedReceive != null)
                {
                    return Ok(updatedReceive); // Return 200 OK with the updated customer
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
        public async Task<ActionResult<object>> DeleteReceive([FromBody] int ReceiveId)
        {
            try
            {
                if (ReceiveId == null)
                {
                    return BadRequest();
                }
                var CreatedRecieve = await _receiveRepos.DeleteReceive(ReceiveId);
                return StatusCode(StatusCodes.Status201Created, CreatedRecieve);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
