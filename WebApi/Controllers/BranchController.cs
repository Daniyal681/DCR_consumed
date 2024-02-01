using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;



namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepos _branchrepos;

        public BranchController(IBranchRepos branchrepos)
        {
            _branchrepos = branchrepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetBranches()
        {

            try
            {
                return Ok(await _branchrepos.GetBranches());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }


        [HttpPost]
        public async Task<ActionResult<object>> GetBranch([FromBody]int BranchId)
        {
            try
            {
                var result = await _branchrepos.GetBranch(BranchId);
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
        public async Task<ActionResult> CreateBranch([FromBody] BranchViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var createdBranch = await _branchrepos.AddBranch(model);

                return StatusCode(StatusCodes.Status201Created, createdBranch);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Creating!");
            }
        }


        [HttpPost]
        public async Task<ActionResult> UpdateBranch(int BranchId, [FromBody] BranchViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedBranch = await _branchrepos.UpdateBranch(BranchId, model);

                if (updatedBranch != null)
                {
                    return Ok(updatedBranch); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Branch not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult> DeleteBranch([FromBody] int BranchId)
        {
            try
            {
                if (BranchId <= 0)
                {
                    return BadRequest();
                }
                var deletedBranch = await _branchrepos.DeleteBranch(BranchId);
                if (deletedBranch == null)
                {
                    return NotFound();
                }
                return Ok(deletedBranch);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Deleting!");
            }
        }
    }
}
