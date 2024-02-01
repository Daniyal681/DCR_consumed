using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;

namespace DCRHelper
{
    public class ApiCall
    {
        //Uri baseAddress = new Uri("http://emsdcr.somee.com/api");
        Uri baseAddress = new Uri("https://localhost:7169/api");
        private readonly HttpClient _httpClient;


        public ApiCall()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public async Task<string> consumeapi(string body = "", string apiPath = "")
        {
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + apiPath, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

       
    }
}