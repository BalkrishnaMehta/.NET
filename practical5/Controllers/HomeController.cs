using Microsoft.AspNetCore.Mvc;

namespace practical5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}