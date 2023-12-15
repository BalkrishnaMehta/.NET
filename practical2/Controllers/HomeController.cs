using Microsoft.AspNetCore.Mvc;

namespace practical2.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("MyView");
        }
    }
}