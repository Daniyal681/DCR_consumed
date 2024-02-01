using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace DCRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepos _warehouseRepos;

        public WarehouseController(IWarehouseRepos warehouseRepos)
        {
            _warehouseRepos = warehouseRepos;
        }

        [HttpPost]
        public async Task<ActionResult> GetWarehouses()
        {

            try
            {
                return Ok(await _warehouseRepos.GetWarehouses());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error Retrieving Data!");

            }

        }

        [HttpPost]
        public async Task<ActionResult<WarehouseViewModel>> GetWarehouse(int WarehouseId)
        {
            try
            {
                var Result = await _warehouseRepos.GetWarehouse(WarehouseId);
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
        public async Task<ActionResult> CreateWarehouse([FromBody] WarehouseViewModel Model)
        {
            try
            {

                if (Model == null)
                {
                    return BadRequest();
                }
                var CreatedWarehouse = await _warehouseRepos.AddWarehouse(Model);
                return StatusCode(StatusCodes.Status201Created, CreatedWarehouse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");

            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateWarehouse([FromBody] WarehouseViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new Exception("Null Data!");
                }

                var UpdatedWarehouse = await _warehouseRepos.UpdateWarehouse(model);

                if (UpdatedWarehouse != null)
                {
                    return Ok(UpdatedWarehouse);
                }
                else
                {
                    throw new Exception("WareHouse Not Found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating: " + ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<object>> DeleteCustomer([FromBody] int WarehouseId)
        {
            try
            {
                if (WarehouseId == null)
                {
                   throw new Exception("Null Data!");
                }
                var DeletedWarehouse = await _warehouseRepos.DeleteWarehouse(WarehouseId);
                return StatusCode(StatusCodes.Status201Created, DeletedWarehouse);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error in Creating!");
            }
        }

    }
}
