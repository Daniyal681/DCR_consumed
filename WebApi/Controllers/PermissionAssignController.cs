using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionAssignController : ControllerBase
    {
        private readonly IMenuPermissionsAsignRepos _menuPermissionsAsignRepos;
        public PermissionAssignController(IMenuPermissionsAsignRepos menuPermissionsAsignRepos)
        {
            _menuPermissionsAsignRepos = menuPermissionsAsignRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetMenuPermissions()
        {

            try
            {
                return Ok(await _menuPermissionsAsignRepos.GetMenuPermissions(1));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<MenuPermissionAssignViewModel>> GetMenuPermission([FromBody] int MenuAssignId)
        {
            try
            {
                var Result = await _menuPermissionsAsignRepos.GetMenuPermission(MenuAssignId);
                if (Result == null)
                {
                    throw new Exception("Null Data!");
                }
                return Result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateMenuPermission([FromBody] MenuPermissionAssignViewModel Model)
        {
            try
            {

                if (Model == null)
                {
                    throw new Exception("Null Data!");
                }
                var CreatedPermission = await _menuPermissionsAsignRepos.AddMenuPermission(Model);
                return StatusCode(StatusCodes.Status201Created, CreatedPermission);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }


        [HttpPost]
        public async Task<ActionResult> UpdateMenuPermission([FromBody] MenuPermissionAssignViewModel Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new Exception("Null Data!");
                }

                var UpdatePermissionAssign = await _menuPermissionsAsignRepos.UpdateMenuPermission(Model);

                if (UpdatePermissionAssign != null)
                {
                    return Ok(UpdatePermissionAssign);
                }
                else
                {
                    return NotFound("Menu Assign not found"); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuPermissionAssign>> DeleteMenuPermission([FromBody] int MenuAssignId)
        {
            try
            {
                if (MenuAssignId == null)
                {
                    throw new Exception("Null Data!");
                }
                var DeletedPermission = await _menuPermissionsAsignRepos.DeleteMenuPermission(MenuAssignId);
                return StatusCode(StatusCodes.Status201Created, DeletedPermission);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }
    }
}
