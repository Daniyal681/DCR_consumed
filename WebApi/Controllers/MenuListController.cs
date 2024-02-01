using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuListController : ControllerBase
    {
        private readonly IMenuListRepos _menuListRepos;

        public MenuListController(IMenuListRepos menuListRepos)
        {
            _menuListRepos = menuListRepos; 
        }

        [HttpPost]
        public async Task<ActionResult> GetMenuLists()
        {

            try
            {
                return Ok(await _menuListRepos.GetMenuLists());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<object>> GetMenuList(int MenuListId)
        {
            try
            {
                var result = await _menuListRepos.GetMenuList(MenuListId);
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
        public async Task<ActionResult<object>> CreateMenuList([FromBody] MenuListViewModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                var CreatedUser = await _menuListRepos.AddMenu(model);
                return CreatedAtAction(nameof(GetMenuList), new { id = CreatedUser.Title}, CreatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }

        [HttpPost]
        public async Task<ActionResult<object>> UpdateMenuList(int MenuListId, [FromBody] MenuListViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data. Please provide valid Menu List data.");
                }

                // Assuming you have a method like UpdateCustomer in your _customerRepos
                var UpdateMenuList = await _menuListRepos.UpdateMenu(MenuListId, model);

                if (UpdateMenuList != null)
                {
                    return Ok(UpdateMenuList); // Return 200 OK with the updated customer
                }
                else
                {
                    return NotFound("Menu List Data not found"); // Return 404 Not Found if the customer doesn't exist
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<object>> DeleteMenuList([FromBody] int MenuListId)
        {
            try
            {
                if (MenuListId == null)
                {
                    return BadRequest();
                }
                var CreatedMenuList = await _menuListRepos.DeleteMenu(MenuListId);
                return StatusCode(StatusCodes.Status201Created, CreatedMenuList);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }



    }
}
