using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepos _inventoryRepos;

        public InventoryController(IInventoryRepos inventoryRepos)
        {
                _inventoryRepos = inventoryRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetInventories()
        {

            try
            {
                return Ok(await _inventoryRepos.GetInventories());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<object>> GetInventory(int InventoryId)
        {
            try
            {
                var result = await _inventoryRepos.GetInventory(InventoryId);
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
        public async Task<ActionResult<object>> CreateInventory([FromBody] InventoryViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _inventoryRepos.AddInventory(model);
                return CreatedAtAction(nameof(GetInventory), new { id = CreatedUser.ProductId }, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }

        [HttpPost]
        public async Task<ActionResult<object>> UpdateInventory(int InventoryId, [FromBody] InventoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid customer data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var updatedInventory = await _inventoryRepos.UpdateInventory(InventoryId, model);

                if (updatedInventory != null)
                {
                    return Ok(updatedInventory); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Data not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> DeleteInventory([FromBody] int InventoryId)
        {
            try
            {
                if (InventoryId == null)
                {
                    return BadRequest();
                }
                var CreatedInventory = await _inventoryRepos.DeleteInventory(InventoryId);
                return StatusCode(StatusCodes.Status201Created, CreatedInventory);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }
    }
}
