using DCR.Helper.ViewModel;
using DCRHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace DCRConsumeWebApi.Controllers
{
    public class CustomerController : Controller
    {
        ApiCall apiCall = new ApiCall();
        JSONRsponse resp = new JSONRsponse();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> GetCustomers(CustomerViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);

            string response = await apiCall.consumeapi(data, "/Customer/GetCustomers");

            return Json(response);

        }






        //[HttpPost]
        //public async Task<JsonResult> AddCustomer(CustomerViewModel model)
        //{
        //    string data = JsonConvert.SerializeObject(model);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Customer/CreateCustomer", content);


        //    // Handle successful response
        //    var responseContent = await response.Content.ReadAsStringAsync();


        //    return Json(responseContent);

        //}





    }
}
