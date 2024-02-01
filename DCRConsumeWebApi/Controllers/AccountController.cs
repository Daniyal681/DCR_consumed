using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using DCRHelper;
using DCR.Helper.ViewModel;

namespace DCRConsumeWebApi.Controllers
{

    public class AccountController : Controller
    {
        ApiCall apiCall = new ApiCall();
        JSONRsponse resp = new JSONRsponse();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CombinedViewModel model)
        {
            try
            {

                // Create an object with user login ID and new password
                var LoginModel = new PasswordUpdateViewModel
                {

                    UserLoginId = model.LoginViewModel.UserLoginId,
                    UserPassword = model.LoginViewModel.UserPassword

                };


                string data = JsonConvert.SerializeObject(LoginModel);

                string response = await apiCall.consumeapi(data, "/Account/LoginUser");

                if (response != "")
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.message = "Inavlid User Or Password";
                }

               

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

            return View();

        }


        [HttpPost]
        public async Task<JsonResult> JSONSendOTP(CombinedViewModel combinedModel)
        {
            try
            {
              
                string data = JsonConvert.SerializeObject(combinedModel.LoginViewModel.UserLoginId);

                string response = await apiCall.consumeapi(data, "/Account/GetUserEmail");

                if (response != null)
                {

                    if (!string.IsNullOrEmpty(response))
                    {
                        combinedModel.OTPViewModel = new OTPViewModel();
                        combinedModel.OTPViewModel.To = response;
                        combinedModel.OTPViewModel.From = "malikdaniyal681@gmail.com";
                        combinedModel.OTPViewModel.Password = "bzbw ense qpcr ticq";
                        combinedModel.OTPViewModel.RandomCode = (new Random()).Next(999999).ToString();
                        combinedModel.OTPViewModel.MessageBody = "You Are Hacked Please Stay Clam:" + combinedModel.OTPViewModel.RandomCode;

                        MailMessage mailMessage = new MailMessage();
                        mailMessage.To.Add(combinedModel.OTPViewModel.To);
                        mailMessage.From = new MailAddress(combinedModel.OTPViewModel.From);
                        mailMessage.Body = combinedModel.OTPViewModel.MessageBody;
                        mailMessage.Subject = "Password Resetting Code";

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(combinedModel.OTPViewModel.From, combinedModel.OTPViewModel.Password);

                        try
                        {
                            await smtp.SendMailAsync(mailMessage);
                            resp.response = true;
                            resp.erorMessage = "OTP Sent Successfully";

                            // Store OTP in session
                            HttpContext.Session.SetString("OTP", combinedModel.OTPViewModel.RandomCode);

                            // Store UserLoginId in session
                            HttpContext.Session.SetString("UserLoginId", combinedModel.LoginViewModel.UserLoginId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);

                        }
                    }
                    else
                    {
                        resp.response = false;
                        resp.erorMessage = "Invalid Login ID";

                    }
                }
                else
                {
                    resp.hasError = true;
                    resp.erorMessage = "Please Enter LoginId";

                }
            }
            catch (Exception ex)
            {
                resp.hasError = true;
                resp.erorMessage = ex.Message;

            }


            return Json(resp);
        }

        
        [HttpPost]
        public async Task<JsonResult> JSONVerifyOTP(CombinedViewModel model)
        {
            try
            {
                string storedOTP = HttpContext.Session.GetString("OTP");

                if (storedOTP == model.OTPViewModel.OTP)
                {
                    resp.response = storedOTP;
                }
                else
                {
                    resp.hasError = true;
                }

            }
            catch (Exception ex)
            {
                resp.hasError = true;
                resp.erorMessage = ex.Message;
            }
            return Json(resp);
        }


        [HttpPost]
        public async Task<JsonResult> JsonMatchPassword(CombinedViewModel combinedModel)
        {


            try
            {
                if (combinedModel.LoginViewModel.UserPassword == combinedModel.LoginViewModel.ConfirmPassword)
                {
                    string storedUserLoginId = HttpContext.Session.GetString("UserLoginId");
                    if (!string.IsNullOrEmpty(storedUserLoginId))
                    {
                        // Create an object with user login ID and new password
                        var UpdateModel = new PasswordUpdateViewModel
                        {

                            UserLoginId = storedUserLoginId,
                            UserPassword = combinedModel.LoginViewModel.UserPassword

                        };

                       
                        string data = JsonConvert.SerializeObject(UpdateModel);

                        string response = await apiCall.consumeapi(data, "/Account/UpdateUserPassword");


                        if (response != null)
                        {
                            resp.response = true;
                        }
                        else
                        {
                            resp.erorMessage = "Password Not Matched";
                        }
                    }
                }
                else
                {
                    resp.hasError = true;
                }
            }
            catch (Exception ex)
            {

                resp.hasError = true;
                resp.erorMessage = ex.Message;
            }

            return Json(resp);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
          
            return RedirectToAction("Login", "Account");
        }



        //---------- User -------------

        [HttpGet]
        public IActionResult User()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddPartialView()
        {
            return PartialView("_AddUserModel");
        }


        [HttpPost]
        public async Task<JsonResult> JsonGetUsers(LoginViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);

            string response = await apiCall.consumeapi(data, "/Account/GetUsers");

            return Json(response);

        }


        [HttpPost]
        public async Task<IActionResult> GetUsers(LoginViewModel model)
        {
            try
            {
                int pageSize = 0;
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                pageSize = !string.IsNullOrEmpty(length) ? Convert.ToInt32(length) : 0;
                int skip = !string.IsNullOrEmpty(start) ? Convert.ToInt32(start) : 0;

                //Fetch data using JSONGetProducts method asynchronously
                var apiresponse = await JsonGetUsers(model);



                // Deserialize the JSON content
                List<LoginViewModel> result = JsonConvert.DeserializeObject<List<LoginViewModel>>(apiresponse.Value.ToString());



                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDir))
                {
                    // Apply sorting based on the selected column and direction
                    if (sortColumnDir.ToLower() == "asc")
                    {
                        result = result.OrderBy(u => u.UserLoginId).ToList();
                    }
                    else
                    {
                        result = result.OrderByDescending(u => u.UserLoginId).ToList();
                    }
                }

                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    // Apply filtering based on the search value
                //    result = result.Where(e =>
                //    e.ProductType.Contains(searchValue) ||
                //    e.MarketName.Contains(searchValue) ||
                //    e.Model.Contains(searchValue) ||
                //    e.Color.Contains(searchValue) ||
                //    e.Brand.Contains(searchValue) ||
                //    e.ProductSku.Contains(searchValue) ||
                //    e.ProductCode.Contains(searchValue) 
                //    ).ToList();
                //}

                int totalRecord = result.Count();
                if (pageSize >= 0)
                {
                    result = result.Skip(skip).Take(pageSize).ToList();
                }

                var jsonData = new
                {
                    draw = draw,
                    recordsFiltered = totalRecord,
                    recordsTotal = totalRecord,
                    data = result,
                };

                return Json(jsonData);

            }
            catch (Exception ex)
            {
                //Handle the exception here
                return StatusCode(500, "Internal Server Error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> JsonGetUser(string UserLoginId)
        {
            LoginViewModel modal = new LoginViewModel();
            try
            {
                if (UserLoginId != null)
                {
                    string data = JsonConvert.SerializeObject(UserLoginId);

                    string response = await apiCall.consumeapi(data, "/Account/GetUser");

                    if (response != null)
                    {
                        // Deserialize the JSON content
                        modal = JsonConvert.DeserializeObject<LoginViewModel>(response.ToString());
                        resp.response = response;

                    }
                    else
                    {
                        resp.response = false;
                        resp.erorMessage = "Data Not Found";
                    }
                }
                else
                {
                    resp.hasError = true;
                    resp.erorMessage = "Please Fill The Form";
                }
            }
            catch (Exception ex)
            {
                resp.hasError = true;
                resp.erorMessage = ex.Message;
            }
            return PartialView("_EditUserModel", modal);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> JsonAddUser(LoginViewModel model)
        {
            try
            {
                if (model != null)
                {
                    string data = JsonConvert.SerializeObject(model);

                    string response = await apiCall.consumeapi(data, "/Account/CreateUser");

                    if (response != null)
                    {
                        resp.response = true;
                        resp.erorMessage = "Record Saved Successfully";
                    }
                    else
                    {
                        resp.response = false;
                        resp.erorMessage = "Record Not Saved";
                    }

                }
                else
                {
                    resp.hasError = true;
                    resp.erorMessage = "Please Fill The Form";
                }
            }
            catch (Exception ex)
            {
                resp.hasError = true;
                resp.erorMessage = ex.Message;
            }

            return Json(resp);


        }

        [HttpPost]
        public async Task<JsonResult> JsonUpdateUser(LoginViewModel model)
        {
            try
            {

                if (model != null)
                {
                    string data = JsonConvert.SerializeObject(model);

                    string response = await apiCall.consumeapi(data, "/Account/UpdateUser");

                    if (response != null)
                    {
                        resp.response = true;
                        resp.erorMessage = "Record Updated Successfully";
                    }
                    else
                    {
                        resp.response = false;
                        resp.erorMessage = "Record Not Updated";
                    }

                }
                else
                {
                    resp.hasError = true;
                    resp.erorMessage = "Please Fill The Form";
                }
            }
            catch (Exception)
            {

                throw;
            }


            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> JsonDelete(string UserLoginId)
        {

            LoginViewModel modal = new LoginViewModel();

            try
            {
                if (UserLoginId != null)
                {
                    string data = JsonConvert.SerializeObject(UserLoginId);

                    string response = await apiCall.consumeapi(data, "/Account/DeleteUser");

                    if (response != null)
                    {
                        // Deserialize the JSON content
                        modal = JsonConvert.DeserializeObject<LoginViewModel>(response.ToString());
                        resp.response = response;
                    }
                    else
                    {
                        resp.response = false;
                        resp.erorMessage = "Data Not Found";
                    }
                }
                else
                {
                    resp.hasError = true;
                    resp.erorMessage = "Somthing Went Wrong";

                }
            }
            catch (Exception ex)
            {
                resp.hasError = true;
                resp.erorMessage = ex.Message;
            }
            return PartialView("_DeleteUserModel", modal);
        }











    }
}

