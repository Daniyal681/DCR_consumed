using DCR.Helper.ViewModel;
using DCRHelper;
using Microsoft.AspNetCore.Mvc;

namespace DCRConsumeWebApi.Controllers
{
    public class InventoryController : Controller
    {
        ApiCall apiCall = new ApiCall();
        JSONRsponse resp = new JSONRsponse();


        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> CustomerInventoryQuery(CustomerInventoryViewModel model)
        {

            return Json(model);
        }
    }
}
