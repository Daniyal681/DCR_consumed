using DCR.Helper.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepos;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepos _roleRepos;
        public RoleController(IRoleRepos roleRepos)
        {
            _roleRepos = roleRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetRoles()
        {

            try
            {
                return Ok(await _roleRepos.GetRoles());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }



        [HttpPost]
        public async Task<ActionResult<object>> GetRole(int RoleId)
        {
            try
            {
                var result = await _roleRepos.GetRole(RoleId);
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
        public async Task<ActionResult<object>> CreateCustomer([FromBody] RoleViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _roleRepos.AddRole(model);
                return CreatedAtAction(nameof(GetRole), new { id = CreatedUser.RoleName}, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }



        [HttpPost]
        public async Task<ActionResult<object>> UpdateRole(int RoleId, [FromBody] RoleViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedCustomer = await _roleRepos.UpdateRole(RoleId, model);

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



        [HttpPost]
        public async Task<ActionResult<object>> DeleteRole([FromBody] int RoleId)
        {
            try
            {
                if (RoleId == null)
                {
                    return BadRequest();
                }
                var CreatedRole = await _roleRepos.DeleteRole(RoleId);
                return StatusCode(StatusCodes.Status201Created, CreatedRole);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
