using Microsoft.AspNetCore.Mvc;

namespace practical8.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Download/GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            string apiUrl = "https://dummy.restapiexample.com/api/v1/employees";

            try
            {
                string content = await DownloadDataAsync(apiUrl);
                return Content(content, "application/json");
            }
            catch (HttpRequestException)
            {
                return BadRequest("Failed to retrieve employee data from the API.");
            }
        }

        private async Task<string> DownloadDataAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }
    }
}
