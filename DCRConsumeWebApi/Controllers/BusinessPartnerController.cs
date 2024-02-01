using DCR.Helper.ViewModel;
using DCRHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DCRConsumeWebApi.Controllers
{
    public class BusinessPartnerController : Controller
    {
        ApiCall apiCall = new ApiCall();


        public IActionResult Index()
        {
            return View();
        }


        //public async Task<JsonResult> BusinessPartner(DistributorViewModel distributorViewModel)
        //{
        //    string data = JsonConvert.SerializeObject(distributorViewModel);

        //    string responseContent = await apiCall.consumeapi(data, "/Distributor/GetDistributors");

        //    return Json(responseContent);
        //}
    }
}
